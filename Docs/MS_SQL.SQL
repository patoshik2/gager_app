/*
Created: 09.04.2021
Modified: 09.04.2021
Model: MSSQL2016
Database: MS SQL Server 2016
*/


-- Create tables section -------------------------------------------------

-- Table Zayavka_zamer

CREATE TABLE [Zayavka_zamer]
(
 [ID_zayavka] Bigint IDENTITY(1,1) NOT NULL,
 [Date_zamer] Date NOT NULL,
 [Time_start_zamer] Time NOT NULL,
 [Time_stop_zamer] Time NOT NULL,
 [Notice] Varchar(150) NULL,
 [ID_status_zamer] Bigint NOT NULL,
 [ID_adress] Bigint NOT NULL,
 [ID_partner] Bigint NOT NULL,
 [ID_profile_worker] Bigint NOT NULL
)
go

-- Create indexes for table Zayavka_zamer

CREATE INDEX [IX_Zayavka_to_Guide_status_zamer] ON [Zayavka_zamer] ([ID_status_zamer])
go

CREATE INDEX [IX_Zayavka_to_Guide_adress] ON [Zayavka_zamer] ([ID_adress],[ID_partner])
go

CREATE INDEX [IX_Counterparty_directory__Zayavka_zamer] ON [Zayavka_zamer] ([ID_partner])
go

CREATE INDEX [IX_Profile_worker__Zayavka_zamer] ON [Zayavka_zamer] ([ID_profile_worker])
go

-- Add keys for table Zayavka_zamer

ALTER TABLE [Zayavka_zamer] ADD CONSTRAINT [ID_zayavka] PRIMARY KEY ([ID_zayavka])
go

-- Table Catalog_room

CREATE TABLE [Catalog_room]
(
 [ID_room] Bigint IDENTITY(1,1) NOT NULL,
 [Name_room] Varchar(15) NOT NULL,
 [Blueprint] Image NULL,
 [ID_adress] Bigint NOT NULL,
 [ID_construct] Bigint NOT NULL,
 [ID_zayavka] Bigint NOT NULL,
 [ID_montag] Bigint NULL,
 [ID_partner] Bigint NOT NULL
)
go

-- Create indexes for table Catalog_room

CREATE INDEX [IX_Guide_room__Guide_vid_construct] ON [Catalog_room] ([ID_construct])
go

CREATE INDEX [IX_Zayavka_zamer__Catalog_room] ON [Catalog_room] ([ID_zayavka])
go

CREATE INDEX [IX_Zayavka_montag__Catalog_room] ON [Catalog_room] ([ID_montag])
go

-- Add keys for table Catalog_room

ALTER TABLE [Catalog_room] ADD CONSTRAINT [ID_room] PRIMARY KEY ([ID_room],[ID_adress],[ID_partner])
go

-- Table Catalog_vid_construct

CREATE TABLE [Catalog_vid_construct]
(
 [ID_construct] Bigint IDENTITY(1,1) NOT NULL,
 [Name_construct] Varchar(13) NOT NULL
)
go

-- Add keys for table Catalog_vid_construct

ALTER TABLE [Catalog_vid_construct] ADD CONSTRAINT [ID_vid_construct] PRIMARY KEY ([ID_construct])
go

-- Table Catalog_cart_client

CREATE TABLE [Catalog_cart_client]
(
 [ID_cart_client] Bigint IDENTITY(1,1) NOT NULL,
 [Date] Date NULL,
 [ID_customer_directory] Bigint NULL
)
go

-- Create indexes for table Catalog_cart_client

CREATE INDEX [IX_Customer_directory__Catalog_cart_client] ON [Catalog_cart_client] ([ID_customer_directory])
go

-- Add keys for table Catalog_cart_client

ALTER TABLE [Catalog_cart_client] ADD CONSTRAINT [ID_cart_client] PRIMARY KEY ([ID_cart_client])
go

-- Table Guide_status_zamer

CREATE TABLE [Guide_status_zamer]
(
 [ID_status_zamer] Bigint IDENTITY(1,1) NOT NULL,
 [Name_status_zamer] Varchar(15) NOT NULL
)
go

-- Add keys for table Guide_status_zamer

ALTER TABLE [Guide_status_zamer] ADD CONSTRAINT [ID_status_zamer] PRIMARY KEY ([ID_status_zamer])
go

-- Table Catalog_tel_number

CREATE TABLE [Catalog_tel_number]
(
 [ID_number_tel] Bigint IDENTITY(1,1) NOT NULL,
 [Number_tel] Varchar(12) NOT NULL,
 [ID_partner] Bigint NOT NULL
)
go

-- Add keys for table Catalog_tel_number

ALTER TABLE [Catalog_tel_number] ADD CONSTRAINT [ID_number_tel] PRIMARY KEY ([ID_number_tel],[ID_partner])
go

-- Table Catalog_adress

CREATE TABLE [Catalog_adress]
(
 [ID_adress] Bigint IDENTITY(1,1) NOT NULL,
 [Burg] Varchar(15) NOT NULL,
 [Ulica] Varchar(30) NOT NULL,
 [Number_dom] Varchar(30) NOT NULL,
 [Number_kvartira] Int NULL,
 [ID_partner] Bigint NOT NULL
)
go

-- Add keys for table Catalog_adress

ALTER TABLE [Catalog_adress] ADD CONSTRAINT [ID_adress] PRIMARY KEY ([ID_adress],[ID_partner])
go

-- Table Zayavka_montag

CREATE TABLE [Zayavka_montag]
(
 [ID_montag] Bigint IDENTITY(1,1) NOT NULL,
 [Date_montag] Date NOT NULL,
 [Time_montag] Time NOT NULL,
 [ID_brigada] Bigint NOT NULL,
 [ID_adress] Bigint NOT NULL,
 [ID_installation_contracts] Bigint NOT NULL,
 [ID_partner] Bigint NULL
)
go

-- Create indexes for table Zayavka_montag

CREATE INDEX [IX_Montag_to_Guide_brigada] ON [Zayavka_montag] ([ID_brigada])
go

CREATE INDEX [IX_Guide_adress__Zayavka_montag] ON [Zayavka_montag] ([ID_adress],[ID_partner])
go

CREATE INDEX [IX_Installation_contracts__Zayavka_montag] ON [Zayavka_montag] ([ID_installation_contracts])
go

-- Add keys for table Zayavka_montag

ALTER TABLE [Zayavka_montag] ADD CONSTRAINT [ID_montag] PRIMARY KEY ([ID_montag])
go

-- Table Catalog_brigada

CREATE TABLE [Catalog_brigada]
(
 [ID_brigada] Bigint IDENTITY(1,1) NOT NULL
)
go

-- Add keys for table Catalog_brigada

ALTER TABLE [Catalog_brigada] ADD CONSTRAINT [ID_brigada] PRIMARY KEY ([ID_brigada])
go

-- Table Position_smeta

CREATE TABLE [Position_smeta]
(
 [ID_position_smeta] Bigint IDENTITY(1,1) NOT NULL,
 [Col] Float NOT NULL,
 [ID_room] Bigint NOT NULL,
 [ID_adress] Bigint NOT NULL,
 [ID_catalog] Bigint NOT NULL,
 [ID_partner] Bigint NOT NULL
)
go

-- Add keys for table Position_smeta

ALTER TABLE [Position_smeta] ADD CONSTRAINT [ID_position_smeta] PRIMARY KEY ([ID_position_smeta],[ID_room],[ID_adress],[ID_catalog],[ID_partner])
go

-- Table Price_vid_construct

CREATE TABLE [Price_vid_construct]
(
 [ID_price_vid_construct] Bigint IDENTITY(1,1) NOT NULL,
 [Date_cost] Date NOT NULL,
 [Cost] Float NOT NULL,
 [ID_construct] Bigint NOT NULL
)
go

-- Add keys for table Price_vid_construct

ALTER TABLE [Price_vid_construct] ADD CONSTRAINT [ID_price_vid_construct] PRIMARY KEY ([ID_price_vid_construct],[ID_construct])
go

-- Table Catalog_mat_usl

CREATE TABLE [Catalog_mat_usl]
(
 [ID_catalog] Bigint IDENTITY(1,1) NOT NULL,
 [Name_mat_usl] Varchar(150) NOT NULL,
 [Image] Image NULL,
 [Last_closing_date] Datetime NOT NULL,
 [residual] Int NOT NULL,
 [ID_units] Bigint NOT NULL,
 [ID_type_mat_usl] Bigint NOT NULL
)
go

-- Create indexes for table Catalog_mat_usl

CREATE INDEX [IX_Catalog_mat_usl__Units] ON [Catalog_mat_usl] ([ID_units])
go

CREATE INDEX [IX_Type_mat_usl__Catalog_mat_usl] ON [Catalog_mat_usl] ([ID_type_mat_usl])
go

-- Add keys for table Catalog_mat_usl

ALTER TABLE [Catalog_mat_usl] ADD CONSTRAINT [ID_catalog] PRIMARY KEY ([ID_catalog])
go

-- Table Price_mat_usl

CREATE TABLE [Price_mat_usl]
(
 [ID_price_mat_usl] Bigint IDENTITY(1,1) NOT NULL,
 [Date] Date NOT NULL,
 [Cost] Float NOT NULL,
 [ID_catalog] Bigint NOT NULL
)
go

-- Add keys for table Price_mat_usl

ALTER TABLE [Price_mat_usl] ADD CONSTRAINT [ID_price_mat_usl] PRIMARY KEY ([ID_price_mat_usl],[ID_catalog])
go

-- Table Units

CREATE TABLE [Units]
(
 [ID_units] Bigint IDENTITY(1,1) NOT NULL,
 [Name] Varchar(10) NOT NULL,
 [IsFloat] Bit NOT NULL
)
go

-- Add keys for table Units

ALTER TABLE [Units] ADD CONSTRAINT [ID_units] PRIMARY KEY ([ID_units])
go

-- Table Type_mat_usl

CREATE TABLE [Type_mat_usl]
(
 [ID_type_mat_usl] Bigint IDENTITY(1,1) NOT NULL,
 [Name] Varchar(15) NOT NULL
)
go

-- Add keys for table Type_mat_usl

ALTER TABLE [Type_mat_usl] ADD CONSTRAINT [ID_type_mat_usl] PRIMARY KEY ([ID_type_mat_usl])
go

-- Table Guide_rol

CREATE TABLE [Guide_rol]
(
 [ID_rol] Bigint IDENTITY(1,1) NOT NULL,
 [Name_rol] Varchar(30) NOT NULL
)
go

-- Add keys for table Guide_rol

ALTER TABLE [Guide_rol] ADD CONSTRAINT [ID_rol] PRIMARY KEY ([ID_rol])
go

-- Table Tipe_works

CREATE TABLE [Tipe_works]
(
 [ID_tipe_works] Bigint IDENTITY(1,1) NOT NULL,
 [Name_tipe_work] Varchar(30) NOT NULL
)
go

-- Add keys for table Tipe_works

ALTER TABLE [Tipe_works] ADD CONSTRAINT [ID_tipe_works] PRIMARY KEY ([ID_tipe_works])
go

-- Table Schedule_vacation

CREATE TABLE [Schedule_vacation]
(
 [ID_schedule_vacation] Bigint IDENTITY(1,1) NOT NULL,
 [start_date] Date NOT NULL,
 [end_date] Bigint NOT NULL,
 [ID_profile_worker] Bigint NOT NULL
)
go

-- Add keys for table Schedule_vacation

ALTER TABLE [Schedule_vacation] ADD CONSTRAINT [ID_schedule_vacation] PRIMARY KEY ([ID_schedule_vacation],[ID_profile_worker])
go

-- Table Movement_goods

CREATE TABLE [Movement_goods]
(
 [ID_movement_doc] Bigint IDENTITY(1,1) NOT NULL,
 [Date_doc] Datetime NOT NULL,
 [number_doc] Int NOT NULL,
 [Tipe_doc] Bit NOT NULL,
 [ID_partner] Bigint NOT NULL
)
go

-- Create indexes for table Movement_goods

CREATE INDEX [IX_Counterparty_directory__Movement_goods] ON [Movement_goods] ([ID_partner])
go

-- Add keys for table Movement_goods

ALTER TABLE [Movement_goods] ADD CONSTRAINT [ID_movement_doc] PRIMARY KEY ([ID_movement_doc])
go

-- Table Counterparty_directory

CREATE TABLE [Counterparty_directory]
(
 [ID_partner] Bigint IDENTITY(1,1) NOT NULL,
 [ID_customer_directory] Bigint NULL
)
go

-- Create indexes for table Counterparty_directory

CREATE INDEX [IX_Customer_directory__Counterparty] ON [Counterparty_directory] ([ID_customer_directory])
go

-- Add keys for table Counterparty_directory

ALTER TABLE [Counterparty_directory] ADD CONSTRAINT [ID_partner] PRIMARY KEY ([ID_partner])
go

-- Table Hiring_work

CREATE TABLE [Hiring_work]
(
 [ID_recruitment] Bigint IDENTITY(1,1) NOT NULL,
 [Date_recruitment] Datetime NOT NULL,
 [Date_dismissal] Datetime NULL,
 [ID_profile_worker] Bigint NOT NULL,
 [ID_job_position] Bigint NOT NULL
)
go

-- Create indexes for table Hiring_work

CREATE INDEX [IX_Hiring_work__Job_positions] ON [Hiring_work] ([ID_job_position])
go

-- Add keys for table Hiring_work

ALTER TABLE [Hiring_work] ADD CONSTRAINT [ID_recruitment] PRIMARY KEY ([ID_recruitment],[ID_profile_worker])
go

-- Table Installation_contracts

CREATE TABLE [Installation_contracts]
(
 [ID_installation_contracts] Bigint IDENTITY(1,1) NOT NULL,
 [Number_contracts] Int NOT NULL,
 [Date_Installation_contracts] Datetime NOT NULL,
 [Sum_for_pay] Float NOT NULL,
 [Tipe_pay] Bit NOT NULL,
 [count_months] Int NULL,
 [Discount] Float NOT NULL
)
go

-- Add keys for table Installation_contracts

ALTER TABLE [Installation_contracts] ADD CONSTRAINT [ID_installation_contracts] PRIMARY KEY ([ID_installation_contracts])
go

-- Table Payment_schedule

CREATE TABLE [Payment_schedule]
(
 [ID_payment_schedule] Bigint IDENTITY(1,1) NOT NULL,
 [Date_payment_schedule] Datetime NOT NULL,
 [Sum_payment_schedule] Float NOT NULL,
 [ID_installation_contracts] Bigint NOT NULL
)
go

-- Add keys for table Payment_schedule

ALTER TABLE [Payment_schedule] ADD CONSTRAINT [ID_payment_schedule] PRIMARY KEY ([ID_payment_schedule],[ID_installation_contracts])
go

-- Table Timesheet

CREATE TABLE [Timesheet]
(
 [ID_timesheet] Bigint IDENTITY(1,1) NOT NULL,
 [Date_timesheet] Datetime NOT NULL,
 [Hours] Bigint NULL,
 [ID_profile_worker] Bigint NOT NULL,
 [ID_work_code] Bigint NOT NULL
)
go

-- Create indexes for table Timesheet

CREATE INDEX [IX_Work_codes__Timesheet] ON [Timesheet] ([ID_work_code])
go

-- Add keys for table Timesheet

ALTER TABLE [Timesheet] ADD CONSTRAINT [ID_timesheet] PRIMARY KEY ([ID_timesheet],[ID_profile_worker])
go

-- Table Count_products

CREATE TABLE [Count_products]
(
 [ID_count_products] Bigint IDENTITY(1,1) NOT NULL,
 [Count] Int NOT NULL,
 [Price_move] Float NOT NULL,
 [ID_catalog] Bigint NOT NULL,
 [ID_movement_doc] Bigint NOT NULL
)
go

-- Add keys for table Count_products

ALTER TABLE [Count_products] ADD CONSTRAINT [ID_count_products] PRIMARY KEY ([ID_count_products],[ID_catalog],[ID_movement_doc])
go

-- Table Customer_directory

CREATE TABLE [Customer_directory]
(
 [ID_customer_directory] Bigint IDENTITY(1,1) NOT NULL,
 [Surname_client] Varchar(30) NOT NULL,
 [Name_client] Varchar(15) NOT NULL,
 [Paternum_client] Varchar(30) NOT NULL,
 [ID_Directory_legal_entities] Bigint NULL
)
go

-- Create indexes for table Customer_directory

CREATE INDEX [IX_Directory_ legal_entities__Customer] ON [Customer_directory] ([ID_Directory_legal_entities])
go

-- Add keys for table Customer_directory

ALTER TABLE [Customer_directory] ADD CONSTRAINT [ID_customer_directory] PRIMARY KEY ([ID_customer_directory])
go

-- Table Directory_ legal_entities

CREATE TABLE [Directory_ legal_entities]
(
 [ID_Directory_legal_entities] Bigint IDENTITY(1,1) NOT NULL,
 [Name_company] Varchar(30) NOT NULL,
 [Full_name_company] Varchar(30) NOT NULL,
 [Inn] Int NOT NULL,
 [ID_partner] Bigint NULL
)
go

-- Create indexes for table Directory_ legal_entities

CREATE INDEX [IX_Counterparty_directory__Directory] ON [Directory_ legal_entities] ([ID_partner])
go

-- Add keys for table Directory_ legal_entities

ALTER TABLE [Directory_ legal_entities] ADD CONSTRAINT [ID_Directory_legal_entities] PRIMARY KEY ([ID_Directory_legal_entities])
go

-- Table E-mail_catalog

CREATE TABLE [E-mail_catalog]
(
 [ID_e-mail_catalog] Bigint IDENTITY(1,1) NOT NULL,
 [E_mail] Varchar(30) NOT NULL,
 [ID_partner] Bigint NOT NULL
)
go

-- Add keys for table E-mail_catalog

ALTER TABLE [E-mail_catalog] ADD CONSTRAINT [ID_e-mail_catalog] PRIMARY KEY ([ID_e-mail_catalog],[ID_partner])
go

-- Table Settlements_counterparties

CREATE TABLE [Settlements_counterparties]
(
 [Settlements_counterparties] Bigint IDENTITY(1,1) NOT NULL,
 [Date] Datetime NOT NULL,
 [Sum_settlements_counterparties] Float NOT NULL,
 [Arrival_expense] Bit NOT NULL,
 [Cash_payment] Bit NOT NULL,
 [ID_installation_contracts] Bigint NULL,
 [ID_partner] Bigint NOT NULL
)
go

-- Create indexes for table Settlements_counterparties

CREATE INDEX [IX_Settlements_counterparties_Installation] ON [Settlements_counterparties] ([ID_installation_contracts])
go

-- Add keys for table Settlements_counterparties

ALTER TABLE [Settlements_counterparties] ADD CONSTRAINT [ID_Settlements_counterparties] PRIMARY KEY ([Settlements_counterparties],[ID_partner])
go

-- Table Profile_worker

CREATE TABLE [Profile_worker]
(
 [ID_profile_worker] Bigint IDENTITY(1,1) NOT NULL,
 [Surname] Varchar(30) NOT NULL,
 [Name] Varchar(15) NOT NULL,
 [Paternum] Varchar(20) NOT NULL,
 [ID_tipe_works] Bigint NOT NULL,
 [ID_brigada] Bigint NULL
)
go

-- Create indexes for table Profile_worker

CREATE INDEX [IX_Tipe_works__Profile_worker] ON [Profile_worker] ([ID_tipe_works])
go

CREATE INDEX [IX_Catalog_brigada__Profile_worker] ON [Profile_worker] ([ID_brigada])
go

-- Add keys for table Profile_worker

ALTER TABLE [Profile_worker] ADD CONSTRAINT [ID_profile_worker] PRIMARY KEY ([ID_profile_worker])
go

-- Table User_profile

CREATE TABLE [User_profile]
(
 [ID_user] Bigint IDENTITY(1,1) NOT NULL,
 [Login] Varchar(20) NOT NULL,
 [Password] Varchar(10) NOT NULL,
 [ID_profile_worker] Bigint NOT NULL,
 [ID_rol] Bigint NOT NULL
)
go

-- Create indexes for table User_profile

CREATE INDEX [IX_Guide_rol__User_profile] ON [User_profile] ([ID_rol])
go

-- Add keys for table User_profile

ALTER TABLE [User_profile] ADD CONSTRAINT [ID] PRIMARY KEY ([ID_user],[ID_profile_worker])
go

-- Table Piecework_payment

CREATE TABLE [Piecework_payment]
(
 [ID_piecework_payment] Bigint IDENTITY(1,1) NOT NULL,
 [Sum_piecework] Float NOT NULL,
 [Start_piecework] Datetime NOT NULL,
 [End_piecework] Datetime NOT NULL,
 [ID_profile_worker] Bigint NOT NULL
)
go

-- Add keys for table Piecework_payment

ALTER TABLE [Piecework_payment] ADD CONSTRAINT [ID_piecework_payment] PRIMARY KEY ([ID_piecework_payment],[ID_profile_worker])
go

-- Table Employee_salary_handbook

CREATE TABLE [Employee_salary_handbook]
(
 [ID_employee_salary_handbook] Bigint IDENTITY(1,1) NOT NULL,
 [Date_salary] Datetime NOT NULL,
 [Sum_salary] Float NOT NULL,
 [Start_salary] Datetime NOT NULL,
 [End_salary] Datetime NOT NULL,
 [ID_profile_worker] Bigint NOT NULL
)
go

-- Add keys for table Employee_salary_handbook

ALTER TABLE [Employee_salary_handbook] ADD CONSTRAINT [ID_employee_salary_handbook] PRIMARY KEY ([ID_employee_salary_handbook],[ID_profile_worker])
go

-- Table Job_positions

CREATE TABLE [Job_positions]
(
 [ID_job_position] Bigint IDENTITY(1,1) NOT NULL,
 [Job_title] Bigint NOT NULL
)
go

-- Add keys for table Job_positions

ALTER TABLE [Job_positions] ADD CONSTRAINT [ID_job_position] PRIMARY KEY ([ID_job_position])
go

-- Table Work_codes

CREATE TABLE [Work_codes]
(
 [ID_work_code] Bigint IDENTITY(1,1) NOT NULL,
 [Signature] Varchar(3) NOT NULL,
 [Name] Varchar(30) NOT NULL
)
go

-- Add keys for table Work_codes

ALTER TABLE [Work_codes] ADD CONSTRAINT [ID_work_code] PRIMARY KEY ([ID_work_code])
go

-- Create foreign keys (relationships) section ------------------------------------------------- 


ALTER TABLE [Zayavka_zamer] ADD CONSTRAINT [Zayavka_to_Guide_status_zamer] FOREIGN KEY ([ID_status_zamer]) REFERENCES [Guide_status_zamer] ([ID_status_zamer]) ON UPDATE NO ACTION ON DELETE NO ACTION
go


ALTER TABLE [Zayavka_zamer] ADD CONSTRAINT [Zayavka_to_Guide_adress] FOREIGN KEY ([ID_adress], [ID_partner]) REFERENCES [Catalog_adress] ([ID_adress], [ID_partner]) ON UPDATE NO ACTION ON DELETE NO ACTION
go


ALTER TABLE [Zayavka_montag] ADD CONSTRAINT [Montag_to_Guide_brigada] FOREIGN KEY ([ID_brigada]) REFERENCES [Catalog_brigada] ([ID_brigada]) ON UPDATE NO ACTION ON DELETE NO ACTION
go


ALTER TABLE [Zayavka_montag] ADD CONSTRAINT [Guide_adress__Zayavka_montag] FOREIGN KEY ([ID_adress], [ID_partner]) REFERENCES [Catalog_adress] ([ID_adress], [ID_partner]) ON UPDATE NO ACTION ON DELETE NO ACTION
go


ALTER TABLE [Catalog_room] ADD CONSTRAINT [Guide_adress__Guide_room] FOREIGN KEY ([ID_adress], [ID_partner]) REFERENCES [Catalog_adress] ([ID_adress], [ID_partner]) ON UPDATE CASCADE ON DELETE CASCADE
go


ALTER TABLE [Position_smeta] ADD CONSTRAINT [Guide_room__Position_smeta] FOREIGN KEY ([ID_room], [ID_adress], [ID_partner]) REFERENCES [Catalog_room] ([ID_room], [ID_adress], [ID_partner]) ON UPDATE CASCADE ON DELETE CASCADE
go


ALTER TABLE [Catalog_room] ADD CONSTRAINT [Guide_room__Guide_vid_construct] FOREIGN KEY ([ID_construct]) REFERENCES [Catalog_vid_construct] ([ID_construct]) ON UPDATE NO ACTION ON DELETE NO ACTION
go


ALTER TABLE [Price_vid_construct] ADD CONSTRAINT [Guide_vid_construct__Price_vid_construct] FOREIGN KEY ([ID_construct]) REFERENCES [Catalog_vid_construct] ([ID_construct]) ON UPDATE CASCADE ON DELETE CASCADE
go


ALTER TABLE [Price_mat_usl] ADD CONSTRAINT [Catalog_mat_usl__Price_mat_usl] FOREIGN KEY ([ID_catalog]) REFERENCES [Catalog_mat_usl] ([ID_catalog]) ON UPDATE CASCADE ON DELETE CASCADE
go


ALTER TABLE [Position_smeta] ADD CONSTRAINT [Position_smeta__Catalog_mat_usl] FOREIGN KEY ([ID_catalog]) REFERENCES [Catalog_mat_usl] ([ID_catalog]) ON UPDATE CASCADE ON DELETE CASCADE
go


ALTER TABLE [Catalog_mat_usl] ADD CONSTRAINT [Catalog_mat_usl__Units] FOREIGN KEY ([ID_units]) REFERENCES [Units] ([ID_units]) ON UPDATE NO ACTION ON DELETE NO ACTION
go


ALTER TABLE [Catalog_mat_usl] ADD CONSTRAINT [Type_mat_usl__Catalog_mat_usl] FOREIGN KEY ([ID_type_mat_usl]) REFERENCES [Type_mat_usl] ([ID_type_mat_usl]) ON UPDATE NO ACTION ON DELETE NO ACTION
go


ALTER TABLE [Catalog_room] ADD CONSTRAINT [Zayavka_zamer__Catalog_room] FOREIGN KEY ([ID_zayavka]) REFERENCES [Zayavka_zamer] ([ID_zayavka]) ON UPDATE NO ACTION ON DELETE NO ACTION
go


ALTER TABLE [Catalog_room] ADD CONSTRAINT [Zayavka_montag__Catalog_room] FOREIGN KEY ([ID_montag]) REFERENCES [Zayavka_montag] ([ID_montag]) ON UPDATE NO ACTION ON DELETE NO ACTION
go


ALTER TABLE [Movement_goods] ADD CONSTRAINT [Counterparty_directory__Movement_goods] FOREIGN KEY ([ID_partner]) REFERENCES [Counterparty_directory] ([ID_partner]) ON UPDATE NO ACTION ON DELETE NO ACTION
go


ALTER TABLE [Zayavka_montag] ADD CONSTRAINT [Installation_contracts__Zayavka_montag] FOREIGN KEY ([ID_installation_contracts]) REFERENCES [Installation_contracts] ([ID_installation_contracts]) ON UPDATE NO ACTION ON DELETE NO ACTION
go


ALTER TABLE [Payment_schedule] ADD CONSTRAINT [Payment_schedule__Installation_contracts] FOREIGN KEY ([ID_installation_contracts]) REFERENCES [Installation_contracts] ([ID_installation_contracts]) ON UPDATE CASCADE ON DELETE CASCADE
go


ALTER TABLE [Count_products] ADD CONSTRAINT [Catalog_mat_usl__Count_products] FOREIGN KEY ([ID_catalog]) REFERENCES [Catalog_mat_usl] ([ID_catalog]) ON UPDATE NO ACTION ON DELETE NO ACTION
go


ALTER TABLE [Count_products] ADD CONSTRAINT [Count_products__Movement_goods] FOREIGN KEY ([ID_movement_doc]) REFERENCES [Movement_goods] ([ID_movement_doc]) ON UPDATE CASCADE ON DELETE CASCADE
go


ALTER TABLE [Catalog_tel_number] ADD CONSTRAINT [Counterparty_directory__Catalog_tel] FOREIGN KEY ([ID_partner]) REFERENCES [Counterparty_directory] ([ID_partner]) ON UPDATE CASCADE ON DELETE CASCADE
go


ALTER TABLE [Catalog_cart_client] ADD CONSTRAINT [Customer_directory__Catalog_cart_client] FOREIGN KEY ([ID_customer_directory]) REFERENCES [Customer_directory] ([ID_customer_directory]) ON UPDATE NO ACTION ON DELETE NO ACTION
go


ALTER TABLE [Counterparty_directory] ADD CONSTRAINT [Customer_directory__Counterparty] FOREIGN KEY ([ID_customer_directory]) REFERENCES [Customer_directory] ([ID_customer_directory]) ON UPDATE NO ACTION ON DELETE NO ACTION
go


ALTER TABLE [Directory_ legal_entities] ADD CONSTRAINT [Counterparty_directory__Directory] FOREIGN KEY ([ID_partner]) REFERENCES [Counterparty_directory] ([ID_partner]) ON UPDATE NO ACTION ON DELETE NO ACTION
go


ALTER TABLE [E-mail_catalog] ADD CONSTRAINT [Counterparty_directory__E-mail_catalog] FOREIGN KEY ([ID_partner]) REFERENCES [Counterparty_directory] ([ID_partner]) ON UPDATE CASCADE ON DELETE CASCADE
go


ALTER TABLE [Customer_directory] ADD CONSTRAINT [Directory_ legal_entities__Customer] FOREIGN KEY ([ID_Directory_legal_entities]) REFERENCES [Directory_ legal_entities] ([ID_Directory_legal_entities]) ON UPDATE NO ACTION ON DELETE NO ACTION
go


ALTER TABLE [Zayavka_zamer] ADD CONSTRAINT [Counterparty_directory__Zayavka_zamer] FOREIGN KEY ([ID_partner]) REFERENCES [Counterparty_directory] ([ID_partner]) ON UPDATE NO ACTION ON DELETE NO ACTION
go


ALTER TABLE [Catalog_adress] ADD CONSTRAINT [Counterparty_directory__Catalog_adress] FOREIGN KEY ([ID_partner]) REFERENCES [Counterparty_directory] ([ID_partner]) ON UPDATE CASCADE ON DELETE CASCADE
go


ALTER TABLE [Settlements_counterparties] ADD CONSTRAINT [Settlements_counterparties_Installation] FOREIGN KEY ([ID_installation_contracts]) REFERENCES [Installation_contracts] ([ID_installation_contracts]) ON UPDATE NO ACTION ON DELETE NO ACTION
go


ALTER TABLE [Settlements_counterparties] ADD CONSTRAINT [Counterparty_directory__Settlements] FOREIGN KEY ([ID_partner]) REFERENCES [Counterparty_directory] ([ID_partner]) ON UPDATE CASCADE ON DELETE CASCADE
go


ALTER TABLE [User_profile] ADD CONSTRAINT [User_profile__Profile_worker] FOREIGN KEY ([ID_profile_worker]) REFERENCES [Profile_worker] ([ID_profile_worker]) ON UPDATE CASCADE ON DELETE CASCADE
go


ALTER TABLE [Schedule_vacation] ADD CONSTRAINT [Profile_worker__Schedule_vacation] FOREIGN KEY ([ID_profile_worker]) REFERENCES [Profile_worker] ([ID_profile_worker]) ON UPDATE CASCADE ON DELETE CASCADE
go


ALTER TABLE [Profile_worker] ADD CONSTRAINT [Tipe_works__Profile_worker] FOREIGN KEY ([ID_tipe_works]) REFERENCES [Tipe_works] ([ID_tipe_works]) ON UPDATE NO ACTION ON DELETE NO ACTION
go


ALTER TABLE [Timesheet] ADD CONSTRAINT [Profile_worker__Timesheet] FOREIGN KEY ([ID_profile_worker]) REFERENCES [Profile_worker] ([ID_profile_worker]) ON UPDATE CASCADE ON DELETE CASCADE
go


ALTER TABLE [User_profile] ADD CONSTRAINT [Guide_rol__User_profile] FOREIGN KEY ([ID_rol]) REFERENCES [Guide_rol] ([ID_rol]) ON UPDATE NO ACTION ON DELETE NO ACTION
go


ALTER TABLE [Hiring_work] ADD CONSTRAINT [Profile_worker__Hiring_work] FOREIGN KEY ([ID_profile_worker]) REFERENCES [Profile_worker] ([ID_profile_worker]) ON UPDATE CASCADE ON DELETE CASCADE
go


ALTER TABLE [Employee_salary_handbook] ADD CONSTRAINT [Profile_worker__Employee_salary] FOREIGN KEY ([ID_profile_worker]) REFERENCES [Profile_worker] ([ID_profile_worker]) ON UPDATE CASCADE ON DELETE CASCADE
go


ALTER TABLE [Piecework_payment] ADD CONSTRAINT [Profile_worker__Piecework_payment] FOREIGN KEY ([ID_profile_worker]) REFERENCES [Profile_worker] ([ID_profile_worker]) ON UPDATE CASCADE ON DELETE CASCADE
go


ALTER TABLE [Profile_worker] ADD CONSTRAINT [Catalog_brigada__Profile_worker] FOREIGN KEY ([ID_brigada]) REFERENCES [Catalog_brigada] ([ID_brigada]) ON UPDATE NO ACTION ON DELETE NO ACTION
go


ALTER TABLE [Zayavka_zamer] ADD CONSTRAINT [Profile_worker__Zayavka_zamer] FOREIGN KEY ([ID_profile_worker]) REFERENCES [Profile_worker] ([ID_profile_worker]) ON UPDATE NO ACTION ON DELETE NO ACTION
go


ALTER TABLE [Hiring_work] ADD CONSTRAINT [Hiring_work__Job_positions] FOREIGN KEY ([ID_job_position]) REFERENCES [Job_positions] ([ID_job_position]) ON UPDATE NO ACTION ON DELETE NO ACTION
go


ALTER TABLE [Timesheet] ADD CONSTRAINT [Work_codes__Timesheet] FOREIGN KEY ([ID_work_code]) REFERENCES [Work_codes] ([ID_work_code]) ON UPDATE NO ACTION ON DELETE NO ACTION
go




