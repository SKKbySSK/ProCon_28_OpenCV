#include"opencv2/opencv.hpp"

class NativeCapture
{
public:
	static cv::VideoCapture Capture;
	static void Start();
	static void Stop();
	static bool Detection;
	static bool IsCapturing;
	static int OutputMode;
	static int Threshold;
	static std::string OverlayText;
	static cv::Mat CurrentMat;
};

public enum OUTPUT_MODE {
	NC_OUTPUT_RAW = 0x00,
	NC_OUTPUT_BINARY = 0x01,
	NC_OUTPUT_GRAY = 0x02,
	NC_OUTPUT_NONE = 0x03
};

namespace ProCV {
	public enum class CaptureOutputMode
	{
		Raw = 0x00,
		Binary = 0x01,
		Gray = 0x02,
		None = 0x03
	};

	public ref class CaptureManager {
	private:
		static int DeviceIndex = 0;

		static std::string SystemStrToStdStr(System::String ^systr) {
			using namespace System::Runtime::InteropServices;
			using namespace System;
			const char *cps = (const char *)(Marshal::StringToHGlobalAnsi(systr)).ToPointer();
			std::string ststr = cps;
			Marshal::FreeHGlobal(IntPtr((void *)cps));
			return ststr;
		}
	public:
		static CaptureManager() {
			NativeCapture::Capture = cv::VideoCapture(DeviceIndex);
		}

		static void StartCapture(bool Detect);
		static void StopCapture();
		static void BeginDetection();
		static void StopDetection();
		static System::Drawing::Bitmap^ Capture();
		static bool IsDetecting();
		static bool IsCapturing();



		static property System::String^ OverlayText {
			System::String^ get() {
				return gcnew System::String(NativeCapture::OverlayText.c_str());
			}
			void set(System::String^ val) {
				NativeCapture::OverlayText = ProCV::CaptureManager::SystemStrToStdStr(val);
			}
		}

		static property ProCV::CaptureOutputMode OutputMode {
			ProCV::CaptureOutputMode get() {
				return (CaptureOutputMode)NativeCapture::OutputMode;
			}
			void set(ProCV::CaptureOutputMode mode) {
				NativeCapture::OutputMode = (int)mode;
			}
		}

		static property int FrameWidth {
			int get() {
				return NativeCapture::Capture.get(CV_CAP_PROP_FRAME_WIDTH);
			}
			void set(int val) {
				NativeCapture::Capture.set(CV_CAP_PROP_FRAME_WIDTH, val);
			}
		}

		static property int FrameHeight {
			int get() {
				return NativeCapture::Capture.get(CV_CAP_PROP_FRAME_HEIGHT);
			}
			void set(int val) {
				NativeCapture::Capture.set(CV_CAP_PROP_FRAME_HEIGHT, val);
			}
		}

		static property int Threshold {
			int get() {
				return NativeCapture::Threshold;
			}
			void set(int val) {
				NativeCapture::Threshold = val;
			}
		}

		static void Release() {
			NativeCapture::Capture.release();
		}
	};
}