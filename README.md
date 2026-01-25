TCP File Transfer Application

Ứng dụng truyền tệp tin qua mạng sử dụng giao thức TCP được phát triển bằng ngôn ngữ C# trên nền tảng .NET Framework 4.7.2. Hệ thống được thiết kế theo mô hình Client-Server, hỗ trợ xác thực người dùng, tải lên (upload), tải về (download) và quản lý danh sách tệp tin trên máy chủ.

1. Các tính năng chính
- Hệ thống Server
+ Quản lý kết nối: Chấp nhận nhiều kết nối từ Client đồng thời thông qua TcpListener.
+ Xác thực bảo mật: Lưu trữ thông tin người dùng trong file users.dat với mật khẩu được băm (hashing) bằng thuật toán SHA256.+ Quản lý lưu trữ: Cho phép cấu hình đường dẫn lưu trữ tệp tin tùy chỉnh.
+ Giới hạn dung lượng: Hỗ trợ truyền tải tệp tin lên đến 2GB và kiểm tra dung lượng đĩa trống trước khi nhận.
+ Activity Log: Theo dõi mọi hoạt động kết nối và truyền tin theo thời gian thực.
_ Hệ thống Client
+ Giao diện trực quan: Sử dụng Windows Forms với các tab riêng biệt cho Đăng nhập/Đăng ký và Truyền tệp.
+ Upload/Download: Hỗ trợ chọn tệp tin qua hộp thoại và theo dõi tiến trình (Progress Bar).
+ Quản lý file: Xem danh sách các tệp tin hiện có trên Server với thông tin kích thước và thời gian.
+ Xử lý bất đồng bộ: Sử dụng Task.Run và async/await để đảm bảo giao diện không bị treo khi truyền dữ liệu lớn.

2. Cấu trúc dự án
- Dự án bao gồm 3 thành phần chính:
+ Server: Xử lý logic phía máy chủ, quản lý phiên làm việc (ClientSession) và xác thực.
+ Client: Giao diện người dùng và dịch vụ gửi yêu cầu truyền tệp.
+ SharedLibrary: Thư viện dùng chung chứa các Models, Enums và giao thức truyền tin (FileTransferProtocol).

3. Công nghệ sử dụng
- Ngôn ngữ: C# 
- Framework: .NET Framework 4.7.2 
- Giao thức: TCP (System.Net.Sockets) 
- Serialization: BinaryFormatter (để đóng gói dữ liệu truyền tải) 
- Bảo mật: SHA256 Hashing 

4. Hướng dẫn cài đặt & Sử dụng
a. Yêu cầu hệ thống
- Visual Studio 2022 trở lên.
- .NET Framework 4.7.2 SDK.

b. Thiết lập Server
- Chạy dự án Server.
- Chọn Port (mặc định là 8888).
- Chọn Storage Path để lưu các tệp tin tải lên.
- Nhấn Start Server.
- Tài khoản Admin mặc định: admin / admin123.

c. Thiết lập Client
- Chạy dự án Client.
- Nhập Server IP (mặc định 127.0.0.1 nếu chạy cùng máy) và Port.
- Nhấn Connect.
- Tiến hành Đăng ký tài khoản mới hoặc Đăng nhập.
- Sau khi đăng nhập thành công, tab File Transfer sẽ được kích hoạt để bạn bắt đầu truyền tệp.

5. Giao thức truyền tin (Protocol)
- Ứng dụng sử dụng một giao thức tùy chỉnh đơn giản:
- Chuỗi (String): Gửi 4 byte độ dài trước, sau đó là mảng byte dữ liệu UTF-8.
- Tệp tin (File): Metadata được gửi trước, sau đó dữ liệu tệp được chia thành các chunk kèm theo kích thước của từng chunk.
