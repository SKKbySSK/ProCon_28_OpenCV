#include "CaptureManager.h"

void NativeCapture::Start()
{
	IsCapturing = true;
	while (IsCapturing)
	{
		cv::Mat frame;
		NativeCapture::Capture >> frame;
		NativeCapture::CurrentMat = frame;

		if (Detection) {
			cv::Mat gray, bin;
			cv::cvtColor(frame, gray, CV_BGR2GRAY);
			cv::threshold(gray, bin, 0, 255, CV_THRESH_BINARY | CV_THRESH_OTSU);

			std::vector < std::vector<cv::Point >> contours;
			cv::findContours(bin, contours, CV_RETR_LIST, CV_CHAIN_APPROX_NONE);

			if (OutputMode != NC_OUTPUT_NONE) {
				cv::Mat output;
				switch (OutputMode)
				{
				case NC_OUTPUT_GRAY:
					output = gray.clone();
					break;
				case NC_OUTPUT_BINARY:
					output = bin.clone();
					break;
				case NC_OUTPUT_RAW:
					output = frame.clone();
					break;
				}

				for (auto contour = contours.begin(); contour != contours.end(); contour++)
				{
					cv::polylines(output, *contour, true, cv::Scalar(0, 255, 0), 1);
				}

				cv::putText(frame, OverlayText, cv::Point(0, 50), CV_FONT_HERSHEY_SIMPLEX, 1, cv::Scalar(255, 255, 255), 1);

				cv::imshow("window", output);
			}
		}
		else if(OutputMode != NC_OUTPUT_NONE)
		{
			cv::putText(frame, OverlayText, cv::Point(0, 50), CV_FONT_HERSHEY_SIMPLEX, 1, cv::Scalar(255, 255, 255), 1);
			cv::imshow("window", frame);
		}

		cv::waitKey(50);
	}
}

cv::VideoCapture NativeCapture::Capture;
std::string NativeCapture::OverlayText = "";
bool NativeCapture::IsCapturing = false;
bool NativeCapture::Detection = false;
int NativeCapture::OutputMode = NC_OUTPUT_RAW;
int NativeCapture::Threshold = 0;
cv::Mat NativeCapture::CurrentMat;

void NativeCapture::Stop() {
	IsCapturing = false;
	cv::destroyAllWindows();
}

void ProCV::CaptureManager::StartCapture(bool Detect) {
	NativeCapture::Detection = Detect;
	NativeCapture::Start();
}

void ProCV::CaptureManager::StopCapture() {
	NativeCapture::Detection = false;
	NativeCapture::Stop();
}

System::Drawing::Bitmap^ ProCV::CaptureManager::Capture() {
	IplImage img = NativeCapture::CurrentMat;
	return gcnew System::Drawing::Bitmap(img.width, img.height, img.widthStep,
		System::Drawing::Imaging::PixelFormat::Format24bppRgb, (System::IntPtr)img.imageData);
}

void ProCV::CaptureManager::BeginDetection() {
	NativeCapture::Detection = true;
}

void ProCV::CaptureManager::StopDetection() {
	NativeCapture::Detection = false;
}

bool ProCV::CaptureManager::IsDetecting() {
	return NativeCapture::Detection;
}

bool ProCV::CaptureManager::IsCapturing() {
	return NativeCapture::IsCapturing;
}