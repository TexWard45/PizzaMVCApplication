-- SQLINES LICENSE FOR EVALUATION USE ONLY
INSERT INTO [UserGroups](Display) VALUES
(N'Mặc định'),
(N'Thành viên'),
(N'Nhân viên'),
(N'Quản trị viên');

-- SQLINES LICENSE FOR EVALUATION USE ONLY
INSERT INTO [Users](Username, [UserGroupId], Password, Fullname, Birth, Address, Phone, Email) VALUES
('admin', 4, '$2y$10$QXE8xnq.xDIsoGr1rdK6Hel7MCavVyJDQmUMvGBDYI5iZeZTyJiG6', 'Admin', '2001-01-01', 'TP.HCM', '0123456789', 'email@game.com'),
('nhatanh', 2, '$2y$10$QPRf.XycU3Jv9Ot7YHes4.ZhXQCwEIIXJp4X4kbSkh5U89t1CBinO', N'Trần Nhật Anh', '2001-01-01', 'TP.HCM', '0123456789', 'email@game.com');

-- SQLINES LICENSE FOR EVALUATION USE ONLY
INSERT INTO [UserGroupPermissions]([UserGroupId], Permission, Value) VALUES
(4, 'admin.login', 1),
(4, 'admin.group', 1),
(4, 'admin.user', 1),
(4, 'admin.category', 1),
(4, 'admin.size', 1),
(4, 'admin.base', 1),
(4, 'admin.topping', 1),
(4, 'admin.pizza', 1),
(4, 'admin.order', 1),
(4, 'admin.statistic', 1);

-- SQLINES LICENSE FOR EVALUATION USE ONLY
INSERT INTO [Status](Display) VALUES
(N'Chờ xác nhận'),
(N'Đang chuẩn bị'),
(N'Đang nướng bánh'),
(N'Đang đóng hộp'),
(N'Đang vận chuyển'),
(N'Đã giao'),
(N'Hủy đơn');

-- SQLINES LICENSE FOR EVALUATION USE ONLY
INSERT INTO Categories(Display) VALUES
(N'Mới'),
(N'Công Thức Đặc Biệt'),
(N'Hải Sản Cao Cấp'),
(N'Thập Cẩm Cao Cấp'),
(N'Truyền Thống');

-- SQLINES LICENSE FOR EVALUATION USE ONLY
INSERT INTO Sizes(Display) VALUES
(N'Nhỏ 6'''''),
(N'Vừa 9'''''),
(N'Lớn 12''''');

-- SQLINES LICENSE FOR EVALUATION USE ONLY
INSERT INTO Bases(Display) VALUES
(N'Dày'),
(N'Mỏng giòn'),
(N'Viền phô mai'),
(N'Viền tôm nướng'),
(N'Viền phô mai xúc xích');

-- SQLINES LICENSE FOR EVALUATION USE ONLY
INSERT INTO Pizzas(CategoryId, Display, Description, Image) VALUES
(2, N'Pizza Hải Sản Đào', N'Tôm, Giăm bông, Đào hòa quyện bùng nổ cùng sốt Thousand Island', '/images/pizza/haisandao.png'),
(3, N'Pizza Hải Sản Cocktail', N'Tôm, cua, giăm bông,... với sốt Thousand Island', '/images/pizza/haisancocktail.png'),
(4, N'Pizza Aloha', N'Thịt nguội, xúc xích tiêu cay và dứa hòa quyện với sốt Thousand Island', '/images/pizza/aloha.png'),
(4, N'Pizza Thịt Xông Khói', N'Thịt giăm bông, thịt xông khói và hai loại rau của ớt xanh, cà chua', '/images/pizza/thitxongkhoi.png'),
(2, N'Pizza Hải Sản Pesto Xanh', N'Tôm, cua, mực và bông cải xanh tươi ngon trên nền sốt Pesto Xanh', '/images/pizza/haisanpestoxanh.png'),
(3, N'Pizza Hải Sản Nhiệt Đới', N'Tôm, nghêu, mực, cua, dứa với sốt Thousand Island', '/images/pizza/haisannhietdoi.png'),
(5, N'Pizza Gà Nướng Dứa', N'Thịt gà mang vị ngọt của dứa kết hợp với vị cay nóng của ớt', '/images/pizza/ganuongdua.png'),
(1, N'Pizza Phượng Hoàng', N'Sự kết hợp giữa thịt Ức ngỗng xông khói châu Âu, cải tím và các loại ớt tạo nên một chiếc bánh tràn đầy hương vị mở ra một năm mới nhiều khởi sắc', '/images/pizza/phuonghoang.png');

-- SQLINES LICENSE FOR EVALUATION USE ONLY
INSERT INTO PizzaDetails(PizzaId, SizeId, BaseId, Price, Quantity) VALUES
(1, 1, 1, 169000, 0),
(1, 2, 1, 249000, 0),
(1, 2, 2, 249000, 0),
(1, 2, 3, 299000, 0),
(1, 2, 4, 349000, 0),
(1, 2, 5, 349000, 0),
(1, 3, 1, 329000, 0),
(1, 3, 2, 329000, 0),
(1, 3, 3, 399000, 0),
(1, 3, 4, 469000, 0),
(1, 3, 5, 469000, 0),
(2, 1, 1, 129000, 5),
(2, 2, 1, 209000, 5),
(2, 2, 2, 209000, 5),
(2, 2, 3, 259000, 0),
(2, 2, 4, 309000, 0),
(2, 2, 5, 309000, 0),
(2, 3, 1, 289000, 5),
(2, 3, 2, 289000, 5),
(2, 3, 3, 359000, 0),
(2, 3, 4, 429000, 0),
(2, 3, 5, 429000, 0),
(3, 1, 1, 119000, 5),
(3, 2, 1, 199000, 5),
(3, 2, 2, 199000, 5),
(3, 2, 3, 249000, 5),
(3, 2, 4, 299000, 5),
(3, 2, 5, 299000, 5),
(3, 3, 1, 279000, 5),
(3, 3, 2, 279000, 5),
(3, 3, 3, 349000, 5),
(3, 3, 4, 419000, 5),
(3, 3, 5, 419000, 5),
(4, 1, 1, 119000, 5),
(4, 2, 1, 199000, 5),
(4, 2, 2, 199000, 5),
(4, 2, 3, 249000, 5),
(4, 2, 4, 299000, 5),
(4, 2, 5, 299000, 5),
(4, 3, 1, 279000, 5),
(4, 3, 2, 279000, 5),
(4, 3, 3, 349000, 5),
(4, 3, 4, 419000, 5),
(4, 3, 5, 419000, 5),
(5, 1, 1, 169000, 5),
(5, 2, 1, 249000, 5),
(5, 2, 2, 249000, 5),
(5, 2, 3, 299000, 5),
(5, 2, 4, 349000, 5),
(5, 2, 5, 349000, 5),
(5, 3, 1, 329000, 5),
(5, 3, 2, 329000, 5),
(5, 3, 3, 399000, 5),
(5, 3, 4, 469000, 5),
(5, 3, 5, 469000, 5),
(6, 1, 1, 139000, 5),
(6, 2, 1, 219000, 5),
(6, 2, 2, 219000, 5),
(6, 2, 3, 269000, 5),
(6, 2, 5, 319000, 5),
(6, 3, 1, 299000, 5),
(6, 3, 2, 299000, 5),
(6, 3, 3, 369000, 5),
(6, 3, 5, 439000, 5),
(7, 1, 1, 119000, 5),
(7, 2, 1, 199000, 5),
(7, 2, 2, 199000, 5),
(7, 2, 3, 249000, 5),
(7, 2, 5, 299000, 5),
(7, 3, 1, 279000, 5),
(7, 3, 2, 279000, 5),
(7, 3, 3, 349000, 5),
(7, 3, 5, 349000, 5),
(8, 2, 1, 219000, 5),
(8, 2, 2, 219000, 5),
(8, 2, 3, 269000, 5),
(8, 2, 5, 269000, 5),
(8, 3, 1, 299000, 5),
(8, 3, 2, 299000, 5),
(8, 3, 3, 369000, 5),
(8, 3, 5, 369000, 5);

INSERT INTO Orders (CustomerUsername, HandlerUsername, TotalPrice, Quantity, Fullname, Address, Phone, PaymentType, OrderType, OrderTime, Note) VALUES
('nhatanh', 'admin', '507000.00', 3, 'Trần Nhật Anh', 'TP.HCM', '0123456789', 0, 0, '00:00:00', ''),
('nhatanh', 'admin', '338000.00', 2, 'Trần Nhật Anh', 'TP.HCM', '0123456789', 0, 0, '00:00:00', ''),
('nhatanh', 'admin', '119000.00', 1, 'Trần Nhật Anh', 'TP.HCM', '0123456789', 0, 0, '00:00:00', ''),
('nhatanh', 'admin', '279000.00', 1, 'Trần Nhật Anh', 'TP.HCM', '0123456789', 0, 0, '00:00:00', ''),
('nhatanh', 'admin', '944000.00', 6, 'Trần Nhật Anh', 'TP.HCM', '0123456789', 2, 0, '00:00:00', ''),
('nhatanh', 'admin', '595000.00', 5, 'Trần Nhật Anh', 'TP.HCM', '0123456789', 0, 0, '00:00:00', ''),
('nhatanh', 'admin', '1156000.00', 4, 'Trần Nhật Anh', 'TP.HCM', '0123456789', 2, 0, '00:00:00', ''),
('nhatanh', 'admin', '477000.00', 3, 'Trần Nhật Anh', 'TP.HCM', '0123456789', 0, 0, '00:00:00', ''),
('nhatanh', 'admin', '547000.00', 3, 'Trần Nhật Anh', 'TP.HCM', '0123456788', 2, 0, '00:00:00', ''),
('nhatanh', 'admin', '199000.00', 1, 'Trần Nhật Anh', 'TP.HCM', '0123456787', 0, 0, '00:00:00', ''),
('nhatanh', 'admin', '119000.00', 1, 'Trần Nhật Anh', 'TP.HCM', '0123456788', 0, 0, '00:00:00', ''),
('nhatanh', 'admin', '199000.00', 1, 'Trần Nhật Anh', 'TP.HCM', '0123456788', 2, 0, '00:00:00', '');

INSERT INTO OrderDetails (OrderId, PizzaDetailId, Price, Quantity) VALUES
(1, 12, '129000.00', 2),
(1, 26, '249000.00', 1),
(2, 65, '119000.00', 1),
(2, 74, '219000.00', 1),
(3, 23, '119000.00', 1),
(4, 29, '279000.00', 1),
(5, 65, '119000.00', 5),
(5, 72, '349000.00', 1),
(6, 23, '119000.00', 5),
(7, 61, '299000.00', 1),
(7, 63, '369000.00', 1),
(7, 74, '219000.00', 1),
(7, 76, '269000.00', 1),
(8, 23, '119000.00', 1),
(8, 56, '139000.00', 1),
(8, 57, '219000.00', 1),
(9, 56, '139000.00', 2),
(9, 77, '269000.00', 1),
(10, 66, '199000.00', 1),
(11, 23, '119000.00', 1),
(12, 24, '199000.00', 1);

INSERT INTO StatusDetails (OrderId, StatusId, TimeCreated) VALUES
(1, 1, '2022-10-21 14:30:52'),
(1, 2, '2022-10-21 14:30:57'),
(1, 3, '2022-10-21 14:37:08'),
(1, 4, '2022-10-21 14:37:13'),
(1, 5, '2022-10-21 14:37:17'),
(2, 1, '2022-10-21 14:37:44'),
(3, 1, '2022-10-21 14:38:11'),
(3, 7, '2022-10-21 14:38:20'),
(4, 1, '2022-11-21 14:46:40'),
(4, 2, '2022-11-21 14:47:29'),
(5, 1, '2022-11-21 14:47:04'),
(5, 2, '2022-11-21 14:47:15'),
(6, 1, '2022-11-21 14:47:49'),
(7, 1, '2022-11-21 14:50:04'),
(7, 7, '2022-11-21 16:04:20'),
(8, 1, '2022-11-21 14:50:32'),
(9, 1, '2022-11-21 14:52:19'),
(9, 2, '2022-11-21 16:04:27'),
(9, 3, '2022-11-21 16:04:33'),
(9, 4, '2022-11-21 16:04:40'),
(9, 5, '2022-11-21 16:04:45'),
(9, 6, '2022-11-21 16:04:51'),
(10, 1, '2022-11-21 14:55:59'),
(11, 1, '2022-11-21 14:56:21'),
(12, 1, '2022-11-21 16:05:14'),
(12, 2, '2022-11-21 16:05:18');