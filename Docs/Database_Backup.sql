-- SQL Manager Lite for SQL Server 5.0.3.53390
-- ---------------------------------------
-- Host      : GagerApp.mssql.somee.com
-- Database  : GagerApp
-- Version   : Microsoft SQL Server 2016 (RTM-GDR) (KB4019088) 13.0.1742.0


--
-- Data for table dbo.Client_profile  (LIMIT 0,500)
--

SET IDENTITY_INSERT dbo.Client_profile ON
GO

INSERT INTO dbo.Client_profile (ID_client, Surname_client, Name_client, Paternum_client)
VALUES 
  (1, N'Александров', N'Борис', N'Викторович')
GO

INSERT INTO dbo.Client_profile (ID_client, Surname_client, Name_client, Paternum_client)
VALUES 
  (2, N'Яковлева', N'Юлия', N'Эдуардовна')
GO

SET IDENTITY_INSERT dbo.Client_profile OFF
GO

--
-- Data for table dbo.Catalog_adress  (LIMIT 0,500)
--

SET IDENTITY_INSERT dbo.Catalog_adress ON
GO

INSERT INTO dbo.Catalog_adress (ID_adress, Burg, Ulica, Number_dom, Number_kvartira, ID_client)
VALUES 
  (1, N'Барнаул', N'Германа Титова', 14, 23, 1)
GO

INSERT INTO dbo.Catalog_adress (ID_adress, Burg, Ulica, Number_dom, Number_kvartira, ID_client)
VALUES 
  (2, N'Барнаул', N'Космонавтов', 23, 14, 2)
GO

SET IDENTITY_INSERT dbo.Catalog_adress OFF
GO

--
-- Data for table dbo.Type_mat_usl  (LIMIT 0,500)
--

SET IDENTITY_INSERT dbo.Type_mat_usl ON
GO

INSERT INTO dbo.Type_mat_usl (ID_type_mat_usl, Name)
VALUES 
  (1, N'Услуга')
GO

INSERT INTO dbo.Type_mat_usl (ID_type_mat_usl, Name)
VALUES 
  (2, N'Материал')
GO

INSERT INTO dbo.Type_mat_usl (ID_type_mat_usl, Name)
VALUES 
  (3, N'Усложнение')
GO

SET IDENTITY_INSERT dbo.Type_mat_usl OFF
GO

--
-- Data for table dbo.Units  (LIMIT 0,500)
--

SET IDENTITY_INSERT dbo.Units ON
GO

INSERT INTO dbo.Units (ID_units, Name, IsFloat)
VALUES 
  (5, N'шт.', 0)
GO

INSERT INTO dbo.Units (ID_units, Name, IsFloat)
VALUES 
  (6, N'м2', 1)
GO

INSERT INTO dbo.Units (ID_units, Name, IsFloat)
VALUES 
  (7, N'м.п.', 1)
GO

INSERT INTO dbo.Units (ID_units, Name, IsFloat)
VALUES 
  (8, N'км', 1)
GO

SET IDENTITY_INSERT dbo.Units OFF
GO

--
-- Data for table dbo.Catalog_mat_usl  (LIMIT 0,500)
--

SET IDENTITY_INSERT dbo.Catalog_mat_usl ON
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (3, N'Белое полотно «Тектум» (мат) с установкой до 3,5м без шва', NULL, 6, 2)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (4, N'Белое полотно «Тектум» (мат) с установкой от 3,5м до 5,5м без шва', NULL, 6, 2)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (5, N'Белое полотно  «Evolution» (мат, глянец, сатин)  с установкой, до 3,8м без шва', NULL, 6, 2)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (6, N'Белое полотно  «Evolution» (мат, глянец, сатин)  с установкой, от 3.8м до 5.7м без шва', NULL, 6, 2)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (7, N'Белое полотно (мат, глянец, сатин) с установкой, до 3.8м без шва', NULL, 6, 2)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (8, N'Белое полотно (глянец) с установкой, от 3.8м до 5.7м без шва', NULL, 6, 2)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (9, N'Белое полотно (мат, сатин) с установкой, от 3,8м до 5,7м без шва', NULL, 6, 2)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (10, N'Цветное полотно (мат, сатин) с установкой, до 3,8м без шва', NULL, 6, 2)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (11, N'Цветное полотно (глянец) с установкой, до 3,8м без шва', NULL, 6, 2)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (12, N'Цветное полотно (мат, сатин, глянец) с установкой, от 3,8м до 5,7м без шва', NULL, 6, 2)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (13, N'Полотно фактурное цветное № 225 (мат) с установкой, до 3,8м без шва', NULL, 6, 2)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (14, N'Полотно фактурное белое (мат) с установкой, до 3,8м без шва', NULL, 6, 2)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (15, N'Спецфактуры с установкой', NULL, 6, 2)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (16, N'Белое полотно  LumFer, (мат, глянец, сатин, мат Raute), с установкой до 3.3м', NULL, 6, 2)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (17, N'Cold Stretching с установкой, до 3,5м', NULL, 6, 2)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (18, N'Cold Stretching с установкой, до 4м', NULL, 6, 2)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (19, N'Тканевое полотно с установкой', NULL, 6, 2)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (20, N'Точка установки тканевого полотна', NULL, 5, 1)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (21, N'Фотопечать нанесение до 3,8м', NULL, 6, 1)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (22, N'Фотопечать нанесение от 3,8м до 5,8м', NULL, 6, 1)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (24, N'Направляющие с установкой  (усиленный пластик)', NULL, 7, 2)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (25, N'Направляющие с установкой (алюминиевый)', NULL, 6, 2)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (26, N'Профиль Евробагет монтаж+профиль', NULL, 7, 2)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (27, N'Профиль Еврокрааб монтаж+профиль', NULL, 7, 2)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (28, N'Профиль Крааб 3.0 монтаж+профиль', NULL, 7, 2)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (29, N'Вставка белая с установкой', NULL, 7, 2)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (30, N'Вставка цветная с установкой', NULL, 7, 2)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (31, N'Угол (с 5 угла)', NULL, 5, 1)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (32, N'Труба (обвод)', NULL, 5, 1)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (33, N'Вытяжка (монтаж)', NULL, 5, 1)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (34, N'Ниша (монтаж)', NULL, 7, 1)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (35, N'Ниша с подворотом (монтаж)', NULL, 7, 1)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (36, N'Гардина (монтаж)', NULL, 7, 1)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (37, N'Скрытая гардина ПК5, увеличенная полка 4см. монтаж+профиль', NULL, 7, 1)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (38, N'Подгардинник стандартный, полка 3см. монтаж+профиль', NULL, 7, 1)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (39, N'Подгардинник MAXI, увеличенная полка 6см.  монтаж+профиль', NULL, 7, 1)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (40, N'Отсекатель подгардинника для контурной засветки', NULL, 7, 2)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (41, N'Разделитель с установкой', NULL, 7, 2)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (42, N'Отбойник', NULL, 7, 2)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (43, N'Криволинейность', NULL, 7, 1)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (44, N'Комбинирование', NULL, 7, 1)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (45, N'Внутренний вырез', NULL, 7, 1)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (46, N'Люстра накладная (монтаж)', NULL, 5, 1)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (47, N'Люстра утопить (монтаж)', NULL, 5, 1)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (48, N'Светильник (монтаж) ШВВП', NULL, 5, 1)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (49, N'Светильник (монтаж) ВВГ+ВАГО', NULL, 5, 1)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (50, N'Светильник (монтаж) ВВГ+ВАГО+ГОФРА', NULL, 5, 1)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (51, N'Светильник (монтаж квадратного, стандартного)', NULL, 5, 1)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (52, N'Светильник (монтаж квадратного, не стандартного)', NULL, 5, 1)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (53, N'Светильник  Армстронг  (монтаж)', NULL, 5, 1)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (54, N'Пульт 2К с установкой', NULL, 5, 2)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (55, N'Пульт 3К с установкой', NULL, 5, 2)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (56, N'Пульт 4К с установкой', NULL, 5, 2)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (57, N'Пульт RGB', NULL, 5, 2)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (58, N'Сложность (карманы, трубы по периметру, отпиливание дверок)', NULL, 5, 3)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (59, N'Работы на высоте (от 3м до 3,8м)', NULL, 5, 3)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (60, N'Работы на высоте (более 3,8м с турой)', NULL, 5, 3)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (61, N'Доставка (в черте города)', NULL, 5, 3)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (62, N'Доставка (за чертой города)', NULL, 8, 3)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (63, N'Контурный профиль прямой монтаж+профиль', NULL, 7, 1)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (64, N'Парящий профиль монтаж+профиль', NULL, 7, 1)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (65, N'Контурный профиль АК5040 3D монтаж+профиль', NULL, 7, 1)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (66, N'Обработка угла (парящий/контурный), начиная с 1-го', NULL, 5, 1)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (67, N'Конструкция из профиля ПФ6838 (линия FLEXY 3см) с диодной лентой 22W (24V)', NULL, 7, 2)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (68, N'Угол световой конструкции', NULL, 5, 2)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (69, N'Конструкция из профиля ПФ7320 (линия FLEXY 5см, жёсткая заглушка) с двумя диодными лентами 9,6W (12V)', NULL, 7, 2)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (70, N'Конструкция из профиля ПФ7320 (линия FLEXY 5см, жёсткая заглушка) с двумя диодными лентами 18W (24V)', NULL, 7, 2)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (71, N'Световая линия из профиля «Эплай», шириной 5-10см с диодной лентой                 9,6W (12V)', NULL, 7, 2)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (72, N'ПФ2146 бесщелевой монтаж+профиль', NULL, 7, 1)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (73, N'Профиль АКС, бесщелевой монтаж+профиль', NULL, 7, 1)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (74, N'Торцевая засветка (ПК-10) монтаж+профиль', NULL, 7, 1)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (75, N'Профиль ПЛ 75, с подсветкой  монтаж+профиль', NULL, 7, 1)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (76, N'КП4080 с подсветкой монтаж+профиль', NULL, 7, 1)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (77, N'ПФ 1608 Контурно-бесщелевой', NULL, 7, 2)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (78, N'ПФ 1608 Контурно-бесщелевой 3D', NULL, 7, 2)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (79, N'Линия SLOTT 40,80 (чёрная/белая),  монтаж+профиль', NULL, 7, 1)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (80, N'Примыкание линии  SLOTT к стене', NULL, 5, 2)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (81, N'Угол линии  SLOTT', NULL, 5, 2)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (82, N'«SLOTT» (ниша)', NULL, 7, 2)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (83, N'Примыкание профиля «SLOTT» к стене', NULL, 5, 2)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (84, N'Торец «SLOTT»', NULL, 5, 2)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (85, N'Угол «SLOTT»', NULL, 5, 2)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (86, N'«LumFer» (ниша)', NULL, 7, 2)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (87, N'Примыкание профиля « LumFer » к стене', NULL, 5, 2)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (88, N'Торец « LumFer »', NULL, 5, 2)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (89, N'Угол «LumFer»', NULL, 5, 2)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (90, N'Профиль угловой с экраном 2000*19*19 OREOL', NULL, 7, 2)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (91, N'Профиль прямой с экраном 2000*15,2*6 OREOL', NULL, 7, 2)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (92, N'Монтаж профиля OREOL', NULL, 7, 1)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (93, N'Обработка угла профиля OREOL', NULL, 5, 1)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (94, N'Монтаж светодиодной ленты в профиль OREOL', NULL, 7, 1)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (95, N'Светодиодная лента RGB 5050 30D 7,2W 12V', NULL, 7, 2)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (96, N'Светодиодная лента RGB 5050 60D 14,4W 12V', NULL, 7, 2)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (97, N'Светодиодная лента (зеленая, красная, синяя) 5050 60D 14,4W 12V', NULL, 7, 2)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (98, N'Светодиодная лента бел хол 2835 60D 4,8W 12V', NULL, 7, 2)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (99, N'Светодиодная лента бел хол 2835 Feron 11W 24V', NULL, 7, 2)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (100, N'Светодиодная лента бел тёпл 2835 120D 9,6W 12V', NULL, 7, 2)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (101, N'Светодиодная лента бел хол 5050 60D 14,4W 12V', NULL, 7, 2)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (102, N'Светодиодная лента бел. хол. 2835 168D 22W 24V LUX', NULL, 7, 2)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (103, N'Светодиодная лента дневной свет. 2835 168D 22W 24V LUX', NULL, 7, 2)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (104, N'Светодиодная лента бел. дневной свет. 4000К  19,2W 24V LUX', NULL, 7, 2)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (105, N'Светодиодная лента GENERAL бел хол 2835 60D 19,2W 12V', NULL, 7, 2)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (106, N'Монтаж светодиодной ленты', NULL, 7, 1)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (107, N'Блок питания 25W 12V', NULL, 5, 2)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (108, N'Блок питания 36W 12V', NULL, 5, 2)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (109, N'Блок питания 60W 12V/24V', NULL, 5, 2)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (110, N'Блок питания 75W 12V', NULL, 5, 2)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (111, N'Блок питания 100W 12V/24V', NULL, 5, 2)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (112, N'Блок питания 120W 12V', NULL, 5, 2)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (114, N'Блок питания 150W 12V/24V', NULL, 5, 2)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (115, N'Блок питания 200W 12V/24V', NULL, 5, 2)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (116, N'Блок питания 250W 12V/24V', NULL, 5, 2)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (117, N'Блок питания 300W 12V/24V', NULL, 5, 2)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (118, N'Apply (резной), длина реза', NULL, 7, 2)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (119, N'Люк LumFer', NULL, 5, 2)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (120, N'Дабл вижн, одна сторона', NULL, 6, 2)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (121, N'Дабл вижн, две стороны', NULL, 6, 2)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (122, N'Полная засветка потолка', NULL, 6, 2)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (123, N'Короб для полной засветки/ дабл вижна
 -с разделителя
', NULL, 7, 2)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (124, N'Короб для полной засветки/ дабл вижна
-с «прищепки»
', NULL, 7, 2)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (125, N'Короб для полной засветки/ дабл вижна
-скрытый (м.п.)
', NULL, 7, 2)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (126, N'3Д фотопечать', NULL, 6, 1)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (127, N'Установка пароизоляции (материалами, предоставляемыми компанией)', NULL, 6, 1)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (128, N'Установка пароизоляции (материалами, предоставляемыми клиентом)', NULL, 6, 1)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (129, N'Установка шумоизоляции потолка (минеральная плита+пароизоляция)', NULL, 6, 1)
GO

INSERT INTO dbo.Catalog_mat_usl (ID_catalog, Name_mat_usl, Image, ID_units, ID_type_mat_usl)
VALUES 
  (130, N'Звукозащита «Технониколь мастер» (минеральная плита) + пароизоляция +расходные материалы, толщина 5см', NULL, 6, 1)
GO

SET IDENTITY_INSERT dbo.Catalog_mat_usl OFF
GO

--
-- Data for table dbo.Catalog_vid_construct  (LIMIT 0,500)
--

SET IDENTITY_INSERT dbo.Catalog_vid_construct ON
GO

INSERT INTO dbo.Catalog_vid_construct (ID_construct, Name_construct)
VALUES 
  (1, N'Одноуровневый')
GO

INSERT INTO dbo.Catalog_vid_construct (ID_construct, Name_construct)
VALUES 
  (2, N'Двухуровневый')
GO

INSERT INTO dbo.Catalog_vid_construct (ID_construct, Name_construct)
VALUES 
  (3, N'Трехуровневый')
GO

SET IDENTITY_INSERT dbo.Catalog_vid_construct OFF
GO

--
-- Data for table dbo.Catalog_tel_number  (LIMIT 0,500)
--

SET IDENTITY_INSERT dbo.Catalog_tel_number ON
GO

INSERT INTO dbo.Catalog_tel_number (ID_number_tel, Number_tel, ID_client)
VALUES 
  (1, N'84353532342', 1)
GO

SET IDENTITY_INSERT dbo.Catalog_tel_number OFF
GO

--
-- Data for table dbo.Guide_rol  (LIMIT 0,500)
--

SET IDENTITY_INSERT dbo.Guide_rol ON
GO

INSERT INTO dbo.Guide_rol (ID_rol, Name_rol)
VALUES 
  (0, N'Замерщик')
GO

INSERT INTO dbo.Guide_rol (ID_rol, Name_rol)
VALUES 
  (1, N'Менеджер')
GO

SET IDENTITY_INSERT dbo.Guide_rol OFF
GO

--
-- Data for table dbo.Guide_status_zamer  (LIMIT 0,500)
--

SET IDENTITY_INSERT dbo.Guide_status_zamer ON
GO

INSERT INTO dbo.Guide_status_zamer (ID_status_zamer, Name_status_zamer)
VALUES 
  (1, N'Новый')
GO

INSERT INTO dbo.Guide_status_zamer (ID_status_zamer, Name_status_zamer)
VALUES 
  (2, N'Замер выполнен')
GO

INSERT INTO dbo.Guide_status_zamer (ID_status_zamer, Name_status_zamer)
VALUES 
  (3, N'Отказ')
GO

INSERT INTO dbo.Guide_status_zamer (ID_status_zamer, Name_status_zamer)
VALUES 
  (6, N'Монтаж')
GO

SET IDENTITY_INSERT dbo.Guide_status_zamer OFF
GO

--
-- Data for table dbo.Price_mat_usl  (LIMIT 0,500)
--

SET IDENTITY_INSERT dbo.Price_mat_usl ON
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (1, N'2020-01-01', 500, 3)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (2, N'2020-01-01', 600, 4)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (4, N'2020-01-01', 350, 5)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (5, N'2020-01-01', 400, 6)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (6, N'2020-01-01', 290, 7)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (7, N'2020-01-01', 350, 8)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (8, N'2020-01-01', 350, 9)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (9, N'2020-01-01', 400, 10)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (10, N'2020-01-01', 350, 11)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (11, N'2020-01-01', 450, 12)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (12, N'2020-01-01', 600, 13)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (13, N'2020-01-01', 600, 14)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (14, N'2020-01-01', 600, 15)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (15, N'2020-01-01', 600, 16)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (16, N'2020-01-01', 350, 17)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (17, N'2020-01-01', 400, 18)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (18, N'2020-01-01', 700, 19)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (20, N'2020-01-01', 250, 20)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (21, N'2020-01-01', 1000, 21)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (22, N'2020-01-01', 2000, 22)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (23, N'2020-01-01', 160, 24)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (24, N'2020-01-01', 240, 25)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (25, N'2020-01-01', 200, 26)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (26, N'2020-01-01', 450, 27)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (27, N'2020-01-01', 700, 28)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (30, N'2020-01-01', 50, 29)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (31, N'2020-01-01', 100, 31)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (32, N'2020-01-01', 200, 32)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (33, N'2020-01-01', 200, 33)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (34, N'2020-01-01', 200, 34)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (35, N'2020-01-01', 600, 35)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (36, N'2020-01-01', 200, 36)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (37, N'2020-01-01', 1200, 37)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (38, N'2020-01-01', 700, 38)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (39, N'2020-01-01', 800, 39)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (40, N'2020-01-01', 400, 40)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (41, N'2020-01-01', 350, 41)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (42, N'2020-01-01', 100, 30)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (43, N'2020-01-01', 350, 42)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (44, N'2020-01-01', 300, 43)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (45, N'2020-01-01', 800, 44)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (46, N'2020-01-01', 300, 45)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (48, N'2020-01-01', 200, 46)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (49, N'2020-01-01', 1500, 47)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (50, N'2020-01-01', 200, 48)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (51, N'2020-01-01', 400, 49)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (52, N'2020-01-01', 600, 50)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (53, N'2020-01-01', 250, 51)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (55, N'2020-01-01', 400, 52)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (56, N'2020-01-01', 400, 53)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (57, N'2020-01-01', 1000, 54)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (58, N'2020-01-01', 1300, 55)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (59, N'2020-01-01', 1500, 56)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (60, N'2020-01-01', 1300, 57)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (61, N'2020-01-01', 500, 58)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (62, N'2020-01-01', 1000, 59)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (63, N'2020-01-01', 5000, 60)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (64, N'2020-01-01', 200, 61)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (65, N'2020-01-01', 10, 62)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (66, N'2020-01-01', 450, 63)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (67, N'2020-01-01', 450, 64)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (68, N'2020-01-01', 450, 65)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (69, N'2020-01-01', 200, 66)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (70, N'2020-01-01', 1600, 67)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (71, N'2020-01-01', 300, 68)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (72, N'2020-01-01', 1900, 69)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (73, N'2020-01-01', 2200, 70)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (74, N'2020-01-01', 2000, 71)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (75, N'2020-01-01', 1500, 72)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (76, N'2020-01-01', 1500, 73)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (77, N'2020-01-01', 1800, 74)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (78, N'2020-01-01', 1700, 75)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (79, N'2020-01-01', 1800, 76)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (80, N'2020-01-01', 1800, 77)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (81, N'2020-01-01', 2000, 78)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (82, N'2020-01-01', 2000, 79)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (83, N'2020-01-01', 300, 80)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (84, N'2020-01-01', 300, 81)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (85, N'2020-01-01', 3300, 82)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (86, N'2020-01-01', 500, 83)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (87, N'2020-01-01', 700, 84)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (88, N'2020-01-01', 500, 85)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (89, N'2020-01-01', 2500, 86)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (90, N'2020-01-01', 500, 87)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (91, N'2020-01-01', 700, 88)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (92, N'2020-01-01', 500, 89)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (93, N'2020-01-01', 200, 90)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (94, N'2020-01-01', 200, 91)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (95, N'2020-01-01', 100, 92)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (96, N'2020-01-01', 200, 93)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (97, N'2020-01-01', 200, 94)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (98, N'2020-01-01', 250, 95)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (99, N'2020-01-01', 300, 96)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (100, N'2020-01-01', 300, 97)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (101, N'2020-01-01', 200, 98)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (102, N'2020-01-01', 250, 99)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (103, N'2020-01-01', 250, 100)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (104, N'2020-01-01', 300, 101)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (105, N'2020-01-01', 400, 102)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (106, N'2020-01-01', 400, 103)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (107, N'2020-01-01', 400, 104)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (108, N'2020-01-01', 400, 105)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (109, N'2020-01-01', 200, 106)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (110, N'2020-01-01', 500, 107)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (111, N'2020-01-01', 600, 108)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (112, N'2020-01-01', 800, 109)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (113, N'2020-01-01', 1000, 110)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (114, N'2020-01-01', 1100, 111)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (115, N'2020-01-01', 1300, 112)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (116, N'2020-01-01', 1500, 114)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (117, N'2020-01-01', 1800, 115)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (118, N'2020-01-01', 2000, 116)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (119, N'2020-01-01', 2300, 117)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (121, N'2020-01-01', 150, 118)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (122, N'2020-01-01', 2900, 119)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (123, N'2020-01-01', 5000, 120)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (124, N'2020-01-01', 6000, 121)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (125, N'2020-01-01', 4500, 122)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (126, N'2020-01-01', 1000, 123)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (127, N'2020-01-01', 1500, 124)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (128, N'2020-01-01', 1000, 125)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (129, N'2020-01-01', 5500, 126)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (130, N'2020-01-01', 200, 127)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (131, N'2020-01-01', 100, 128)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (132, N'2020-01-01', 350, 129)
GO

INSERT INTO dbo.Price_mat_usl (ID_price_mat_usl, Date, Cost, ID_catalog)
VALUES 
  (133, N'2020-01-01', 250, 130)
GO

SET IDENTITY_INSERT dbo.Price_mat_usl OFF
GO

--
-- Data for table dbo.Price_vid_construct  (LIMIT 0,500)
--

SET IDENTITY_INSERT dbo.Price_vid_construct ON
GO

INSERT INTO dbo.Price_vid_construct (ID_price_vid_construct, Date_cost, Cost, ID_construct)
VALUES 
  (1, N'2020-01-01', 2000, 1)
GO

INSERT INTO dbo.Price_vid_construct (ID_price_vid_construct, Date_cost, Cost, ID_construct)
VALUES 
  (3, N'2020-01-01', 3000, 2)
GO

INSERT INTO dbo.Price_vid_construct (ID_price_vid_construct, Date_cost, Cost, ID_construct)
VALUES 
  (4, N'2020-01-01', 4000, 3)
GO

SET IDENTITY_INSERT dbo.Price_vid_construct OFF
GO

--
-- Data for table dbo.User_profile  (LIMIT 0,500)
--

SET IDENTITY_INSERT dbo.User_profile ON
GO

INSERT INTO dbo.User_profile (ID_user, Surname, Name, Paternum, Login, Password, ID_rol, ID_brigada)
VALUES 
  (1, N'Тестовый', N'Пользователь', N'1', N'testuser1', N'testuser1', 0, NULL)
GO

SET IDENTITY_INSERT dbo.User_profile OFF
GO


--
-- Data for table dbo.Zayavka_zamer  (LIMIT 0,500)
--

SET IDENTITY_INSERT dbo.Zayavka_zamer ON
GO

INSERT INTO dbo.Zayavka_zamer (ID_zayavka, Date_zamer, Time_start_zamer, Time_stop_zamer, Notice, ID_user, ID_client, ID_status_zamer, ID_adress)
VALUES 
  (6, N'2020-11-23', N'12:00:00.0000000', N'14:00:00.0000000', NULL, 1, 1, 1, 1)
GO

SET IDENTITY_INSERT dbo.Zayavka_zamer OFF
GO

