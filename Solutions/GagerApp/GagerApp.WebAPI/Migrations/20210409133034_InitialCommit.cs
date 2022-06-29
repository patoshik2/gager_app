using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GagerApp.WebAPI.Migrations
{
    public partial class InitialCommit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Catalog_brigada",
                columns: table => new
                {
                    ID_brigada = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("ID_brigada", x => x.ID_brigada);
                });

            migrationBuilder.CreateTable(
                name: "Catalog_vid_construct",
                columns: table => new
                {
                    ID_construct = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_construct = table.Column<string>(unicode: false, maxLength: 13, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ID_vid_construct", x => x.ID_construct);
                });

            migrationBuilder.CreateTable(
                name: "Guide_rol",
                columns: table => new
                {
                    ID_rol = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_rol = table.Column<string>(unicode: false, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ID_rol", x => x.ID_rol);
                });

            migrationBuilder.CreateTable(
                name: "Guide_status_zamer",
                columns: table => new
                {
                    ID_status_zamer = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_status_zamer = table.Column<string>(unicode: false, maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ID_status_zamer", x => x.ID_status_zamer);
                });

            migrationBuilder.CreateTable(
                name: "Installation_contracts",
                columns: table => new
                {
                    ID_installation_contracts = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number_contracts = table.Column<int>(nullable: false),
                    Date_Installation_contracts = table.Column<DateTime>(type: "datetime", nullable: false),
                    Sum_for_pay = table.Column<double>(nullable: false),
                    Tipe_pay = table.Column<bool>(nullable: false),
                    count_months = table.Column<int>(nullable: true),
                    Discount = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ID_installation_contracts", x => x.ID_installation_contracts);
                });

            migrationBuilder.CreateTable(
                name: "Job_positions",
                columns: table => new
                {
                    ID_job_position = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Job_title = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ID_job_position", x => x.ID_job_position);
                });

            migrationBuilder.CreateTable(
                name: "Tipe_works",
                columns: table => new
                {
                    ID_tipe_works = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_tipe_work = table.Column<string>(unicode: false, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ID_tipe_works", x => x.ID_tipe_works);
                });

            migrationBuilder.CreateTable(
                name: "Type_mat_usl",
                columns: table => new
                {
                    ID_type_mat_usl = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(unicode: false, maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ID_type_mat_usl", x => x.ID_type_mat_usl);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    ID_units = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    IsFloat = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ID_units", x => x.ID_units);
                });

            migrationBuilder.CreateTable(
                name: "Work_codes",
                columns: table => new
                {
                    ID_work_code = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Signature = table.Column<string>(unicode: false, maxLength: 3, nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ID_work_code", x => x.ID_work_code);
                });

            migrationBuilder.CreateTable(
                name: "Price_vid_construct",
                columns: table => new
                {
                    ID_price_vid_construct = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_construct = table.Column<long>(nullable: false),
                    Date_cost = table.Column<DateTime>(type: "date", nullable: false),
                    Cost = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ID_price_vid_construct", x => new { x.ID_price_vid_construct, x.ID_construct });
                    table.ForeignKey(
                        name: "Guide_vid_construct__Price_vid_construct",
                        column: x => x.ID_construct,
                        principalTable: "Catalog_vid_construct",
                        principalColumn: "ID_construct",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payment_schedule",
                columns: table => new
                {
                    ID_payment_schedule = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_installation_contracts = table.Column<long>(nullable: false),
                    Date_payment_schedule = table.Column<DateTime>(type: "datetime", nullable: false),
                    Sum_payment_schedule = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ID_payment_schedule", x => new { x.ID_payment_schedule, x.ID_installation_contracts });
                    table.ForeignKey(
                        name: "Payment_schedule__Installation_contracts",
                        column: x => x.ID_installation_contracts,
                        principalTable: "Installation_contracts",
                        principalColumn: "ID_installation_contracts",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Profile_worker",
                columns: table => new
                {
                    ID_profile_worker = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Surname = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 15, nullable: false),
                    Paternum = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    ID_tipe_works = table.Column<long>(nullable: false),
                    ID_brigada = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ID_profile_worker", x => x.ID_profile_worker);
                    table.ForeignKey(
                        name: "Catalog_brigada__Profile_worker",
                        column: x => x.ID_brigada,
                        principalTable: "Catalog_brigada",
                        principalColumn: "ID_brigada",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Tipe_works__Profile_worker",
                        column: x => x.ID_tipe_works,
                        principalTable: "Tipe_works",
                        principalColumn: "ID_tipe_works",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Catalog_mat_usl",
                columns: table => new
                {
                    ID_catalog = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_mat_usl = table.Column<string>(unicode: false, maxLength: 150, nullable: false),
                    Image = table.Column<byte[]>(type: "image", nullable: true),
                    Last_closing_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    residual = table.Column<double>(nullable: false),
                    ID_units = table.Column<long>(nullable: false),
                    ID_type_mat_usl = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ID_catalog", x => x.ID_catalog);
                    table.ForeignKey(
                        name: "Type_mat_usl__Catalog_mat_usl",
                        column: x => x.ID_type_mat_usl,
                        principalTable: "Type_mat_usl",
                        principalColumn: "ID_type_mat_usl",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Catalog_mat_usl__Units",
                        column: x => x.ID_units,
                        principalTable: "Units",
                        principalColumn: "ID_units",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employee_salary_handbook",
                columns: table => new
                {
                    ID_employee_salary_handbook = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_profile_worker = table.Column<long>(nullable: false),
                    Date_salary = table.Column<DateTime>(type: "datetime", nullable: false),
                    Sum_salary = table.Column<double>(nullable: false),
                    Start_salary = table.Column<DateTime>(type: "datetime", nullable: false),
                    End_salary = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ID_employee_salary_handbook", x => new { x.ID_employee_salary_handbook, x.ID_profile_worker });
                    table.ForeignKey(
                        name: "Profile_worker__Employee_salary",
                        column: x => x.ID_profile_worker,
                        principalTable: "Profile_worker",
                        principalColumn: "ID_profile_worker",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hiring_work",
                columns: table => new
                {
                    ID_recruitment = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_profile_worker = table.Column<long>(nullable: false),
                    Date_recruitment = table.Column<DateTime>(type: "datetime", nullable: false),
                    Date_dismissal = table.Column<DateTime>(type: "datetime", nullable: true),
                    ID_job_position = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ID_recruitment", x => new { x.ID_recruitment, x.ID_profile_worker });
                    table.ForeignKey(
                        name: "Hiring_work__Job_positions",
                        column: x => x.ID_job_position,
                        principalTable: "Job_positions",
                        principalColumn: "ID_job_position",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Profile_worker__Hiring_work",
                        column: x => x.ID_profile_worker,
                        principalTable: "Profile_worker",
                        principalColumn: "ID_profile_worker",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Piecework_payment",
                columns: table => new
                {
                    ID_piecework_payment = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_profile_worker = table.Column<long>(nullable: false),
                    Sum_piecework = table.Column<double>(nullable: false),
                    Start_piecework = table.Column<DateTime>(type: "datetime", nullable: false),
                    End_piecework = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ID_piecework_payment", x => new { x.ID_piecework_payment, x.ID_profile_worker });
                    table.ForeignKey(
                        name: "Profile_worker__Piecework_payment",
                        column: x => x.ID_profile_worker,
                        principalTable: "Profile_worker",
                        principalColumn: "ID_profile_worker",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Schedule_vacation",
                columns: table => new
                {
                    ID_schedule_vacation = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_profile_worker = table.Column<long>(nullable: false),
                    start_date = table.Column<DateTime>(type: "date", nullable: false),
                    end_date = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ID_schedule_vacation", x => new { x.ID_schedule_vacation, x.ID_profile_worker });
                    table.ForeignKey(
                        name: "Profile_worker__Schedule_vacation",
                        column: x => x.ID_profile_worker,
                        principalTable: "Profile_worker",
                        principalColumn: "ID_profile_worker",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Timesheet",
                columns: table => new
                {
                    ID_timesheet = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_profile_worker = table.Column<long>(nullable: false),
                    Date_timesheet = table.Column<DateTime>(type: "datetime", nullable: false),
                    Hours = table.Column<long>(nullable: true),
                    ID_work_code = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ID_timesheet", x => new { x.ID_timesheet, x.ID_profile_worker });
                    table.ForeignKey(
                        name: "Profile_worker__Timesheet",
                        column: x => x.ID_profile_worker,
                        principalTable: "Profile_worker",
                        principalColumn: "ID_profile_worker",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Work_codes__Timesheet",
                        column: x => x.ID_work_code,
                        principalTable: "Work_codes",
                        principalColumn: "ID_work_code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User_profile",
                columns: table => new
                {
                    ID_user = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_profile_worker = table.Column<long>(nullable: false),
                    Login = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    Password = table.Column<string>(unicode: false, nullable: false),
                    ID_rol = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ID", x => new { x.ID_user, x.ID_profile_worker });
                    table.ForeignKey(
                        name: "User_profile__Profile_worker",
                        column: x => x.ID_profile_worker,
                        principalTable: "Profile_worker",
                        principalColumn: "ID_profile_worker",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Guide_rol__User_profile",
                        column: x => x.ID_rol,
                        principalTable: "Guide_rol",
                        principalColumn: "ID_rol",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Price_mat_usl",
                columns: table => new
                {
                    ID_price_mat_usl = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_catalog = table.Column<long>(nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Cost = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ID_price_mat_usl", x => new { x.ID_price_mat_usl, x.ID_catalog });
                    table.ForeignKey(
                        name: "Catalog_mat_usl__Price_mat_usl",
                        column: x => x.ID_catalog,
                        principalTable: "Catalog_mat_usl",
                        principalColumn: "ID_catalog",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Catalog_room",
                columns: table => new
                {
                    ID_room = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_adress = table.Column<long>(nullable: false),
                    ID_partner = table.Column<long>(nullable: false),
                    Name_room = table.Column<string>(unicode: false, maxLength: 15, nullable: false),
                    Blueprint = table.Column<byte[]>(type: "image", nullable: true),
                    ID_construct = table.Column<long>(nullable: false),
                    ID_zayavka = table.Column<long>(nullable: false),
                    ID_montag = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ID_room", x => new { x.ID_room, x.ID_adress, x.ID_partner });
                    table.ForeignKey(
                        name: "Guide_room__Guide_vid_construct",
                        column: x => x.ID_construct,
                        principalTable: "Catalog_vid_construct",
                        principalColumn: "ID_construct",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Position_smeta",
                columns: table => new
                {
                    ID_position_smeta = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_room = table.Column<long>(nullable: false),
                    ID_adress = table.Column<long>(nullable: false),
                    ID_catalog = table.Column<long>(nullable: false),
                    ID_partner = table.Column<long>(nullable: false),
                    Col = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ID_position_smeta", x => new { x.ID_position_smeta, x.ID_room, x.ID_adress, x.ID_catalog, x.ID_partner });
                    table.ForeignKey(
                        name: "Position_smeta__Catalog_mat_usl",
                        column: x => x.ID_catalog,
                        principalTable: "Catalog_mat_usl",
                        principalColumn: "ID_catalog",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Guide_room__Position_smeta",
                        columns: x => new { x.ID_room, x.ID_adress, x.ID_partner },
                        principalTable: "Catalog_room",
                        principalColumns: new[] { "ID_room", "ID_adress", "ID_partner" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Zayavka_montag",
                columns: table => new
                {
                    ID_montag = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date_montag = table.Column<DateTime>(type: "date", nullable: false),
                    Time_montag = table.Column<TimeSpan>(nullable: false),
                    ID_brigada = table.Column<long>(nullable: false),
                    ID_adress = table.Column<long>(nullable: false),
                    ID_installation_contracts = table.Column<long>(nullable: false),
                    ID_partner = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ID_montag", x => x.ID_montag);
                    table.ForeignKey(
                        name: "Montag_to_Guide_brigada",
                        column: x => x.ID_brigada,
                        principalTable: "Catalog_brigada",
                        principalColumn: "ID_brigada",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Installation_contracts__Zayavka_montag",
                        column: x => x.ID_installation_contracts,
                        principalTable: "Installation_contracts",
                        principalColumn: "ID_installation_contracts",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Zayavka_zamer",
                columns: table => new
                {
                    ID_zayavka = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date_zamer = table.Column<DateTime>(type: "date", nullable: false),
                    Time_start_zamer = table.Column<TimeSpan>(nullable: false),
                    Time_stop_zamer = table.Column<TimeSpan>(nullable: false),
                    Notice = table.Column<string>(unicode: false, maxLength: 150, nullable: true),
                    ID_status_zamer = table.Column<long>(nullable: false),
                    ID_adress = table.Column<long>(nullable: false),
                    ID_partner = table.Column<long>(nullable: false),
                    ID_profile_worker = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ID_zayavka", x => x.ID_zayavka);
                    table.ForeignKey(
                        name: "Profile_worker__Zayavka_zamer",
                        column: x => x.ID_profile_worker,
                        principalTable: "Profile_worker",
                        principalColumn: "ID_profile_worker",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Zayavka_to_Guide_status_zamer",
                        column: x => x.ID_status_zamer,
                        principalTable: "Guide_status_zamer",
                        principalColumn: "ID_status_zamer",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Count_products",
                columns: table => new
                {
                    ID_count_products = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_catalog = table.Column<long>(nullable: false),
                    ID_movement_doc = table.Column<long>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    Price_move = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ID_count_products", x => new { x.ID_count_products, x.ID_catalog, x.ID_movement_doc });
                    table.ForeignKey(
                        name: "Catalog_mat_usl__Count_products",
                        column: x => x.ID_catalog,
                        principalTable: "Catalog_mat_usl",
                        principalColumn: "ID_catalog",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Catalog_adress",
                columns: table => new
                {
                    ID_adress = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_partner = table.Column<long>(nullable: false),
                    Burg = table.Column<string>(unicode: false, maxLength: 15, nullable: false),
                    Ulica = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    Number_dom = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    Number_kvartira = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ID_adress", x => new { x.ID_adress, x.ID_partner });
                });

            migrationBuilder.CreateTable(
                name: "Catalog_tel_number",
                columns: table => new
                {
                    ID_number_tel = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_partner = table.Column<long>(nullable: false),
                    Number_tel = table.Column<string>(unicode: false, maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ID_number_tel", x => new { x.ID_number_tel, x.ID_partner });
                });

            migrationBuilder.CreateTable(
                name: "Directory_ legal_entities",
                columns: table => new
                {
                    ID_Directory_legal_entities = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_company = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    Full_name_company = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    Inn = table.Column<int>(nullable: false),
                    ID_partner = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ID_Directory_legal_entities", x => x.ID_Directory_legal_entities);
                });

            migrationBuilder.CreateTable(
                name: "Customer_directory",
                columns: table => new
                {
                    ID_customer_directory = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Surname_client = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    Name_client = table.Column<string>(unicode: false, maxLength: 15, nullable: false),
                    Paternum_client = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    ID_Directory_legal_entities = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ID_customer_directory", x => x.ID_customer_directory);
                    table.ForeignKey(
                        name: "Directory_ legal_entities__Customer",
                        column: x => x.ID_Directory_legal_entities,
                        principalTable: "Directory_ legal_entities",
                        principalColumn: "ID_Directory_legal_entities",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Catalog_cart_client",
                columns: table => new
                {
                    ID_cart_client = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "date", nullable: true),
                    ID_customer_directory = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ID_cart_client", x => x.ID_cart_client);
                    table.ForeignKey(
                        name: "Customer_directory__Catalog_cart_client",
                        column: x => x.ID_customer_directory,
                        principalTable: "Customer_directory",
                        principalColumn: "ID_customer_directory",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Counterparty_directory",
                columns: table => new
                {
                    ID_partner = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_customer_directory = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ID_partner", x => x.ID_partner);
                    table.ForeignKey(
                        name: "Customer_directory__Counterparty",
                        column: x => x.ID_customer_directory,
                        principalTable: "Customer_directory",
                        principalColumn: "ID_customer_directory",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "E-mail_catalog",
                columns: table => new
                {
                    ID_email_catalog = table.Column<long>(name: "ID_e-mail_catalog", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_partner = table.Column<long>(nullable: false),
                    E_mail = table.Column<string>(unicode: false, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ID_e-mail_catalog", x => new { x.ID_email_catalog, x.ID_partner });
                    table.ForeignKey(
                        name: "Counterparty_directory__E-mail_catalog",
                        column: x => x.ID_partner,
                        principalTable: "Counterparty_directory",
                        principalColumn: "ID_partner",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Movement_goods",
                columns: table => new
                {
                    ID_movement_doc = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date_doc = table.Column<DateTime>(type: "datetime", nullable: false),
                    number_doc = table.Column<int>(nullable: false),
                    Tipe_doc = table.Column<bool>(nullable: false),
                    ID_partner = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ID_movement_doc", x => x.ID_movement_doc);
                    table.ForeignKey(
                        name: "Counterparty_directory__Movement_goods",
                        column: x => x.ID_partner,
                        principalTable: "Counterparty_directory",
                        principalColumn: "ID_partner",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Settlements_counterparties",
                columns: table => new
                {
                    Settlements_counterparties = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_partner = table.Column<long>(nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Sum_settlements_counterparties = table.Column<double>(nullable: false),
                    Arrival_expense = table.Column<bool>(nullable: false),
                    Cash_payment = table.Column<bool>(nullable: false),
                    ID_installation_contracts = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ID_Settlements_counterparties", x => new { x.Settlements_counterparties, x.ID_partner });
                    table.ForeignKey(
                        name: "Settlements_counterparties_Installation",
                        column: x => x.ID_installation_contracts,
                        principalTable: "Installation_contracts",
                        principalColumn: "ID_installation_contracts",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Counterparty_directory__Settlements",
                        column: x => x.ID_partner,
                        principalTable: "Counterparty_directory",
                        principalColumn: "ID_partner",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_adress_ID_partner",
                table: "Catalog_adress",
                column: "ID_partner");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_directory__Catalog_cart_client",
                table: "Catalog_cart_client",
                column: "ID_customer_directory");

            migrationBuilder.CreateIndex(
                name: "IX_Type_mat_usl__Catalog_mat_usl",
                table: "Catalog_mat_usl",
                column: "ID_type_mat_usl");

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_mat_usl__Units",
                table: "Catalog_mat_usl",
                column: "ID_units");

            migrationBuilder.CreateIndex(
                name: "IX_Guide_room__Guide_vid_construct",
                table: "Catalog_room",
                column: "ID_construct");

            migrationBuilder.CreateIndex(
                name: "IX_Zayavka_montag__Catalog_room",
                table: "Catalog_room",
                column: "ID_montag");

            migrationBuilder.CreateIndex(
                name: "IX_Zayavka_zamer__Catalog_room",
                table: "Catalog_room",
                column: "ID_zayavka");

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_room_ID_adress_ID_partner",
                table: "Catalog_room",
                columns: new[] { "ID_adress", "ID_partner" });

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_tel_number_ID_partner",
                table: "Catalog_tel_number",
                column: "ID_partner");

            migrationBuilder.CreateIndex(
                name: "IX_Count_products_ID_catalog",
                table: "Count_products",
                column: "ID_catalog");

            migrationBuilder.CreateIndex(
                name: "IX_Count_products_ID_movement_doc",
                table: "Count_products",
                column: "ID_movement_doc");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_directory__Counterparty",
                table: "Counterparty_directory",
                column: "ID_customer_directory");

            migrationBuilder.CreateIndex(
                name: "IX_Directory_ legal_entities__Customer",
                table: "Customer_directory",
                column: "ID_Directory_legal_entities");

            migrationBuilder.CreateIndex(
                name: "IX_Counterparty_directory__Directory",
                table: "Directory_ legal_entities",
                column: "ID_partner");

            migrationBuilder.CreateIndex(
                name: "IX_E-mail_catalog_ID_partner",
                table: "E-mail_catalog",
                column: "ID_partner");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_salary_handbook_ID_profile_worker",
                table: "Employee_salary_handbook",
                column: "ID_profile_worker");

            migrationBuilder.CreateIndex(
                name: "IX_Hiring_work__Job_positions",
                table: "Hiring_work",
                column: "ID_job_position");

            migrationBuilder.CreateIndex(
                name: "IX_Hiring_work_ID_profile_worker",
                table: "Hiring_work",
                column: "ID_profile_worker");

            migrationBuilder.CreateIndex(
                name: "IX_Counterparty_directory__Movement_goods",
                table: "Movement_goods",
                column: "ID_partner");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_schedule_ID_installation_contracts",
                table: "Payment_schedule",
                column: "ID_installation_contracts");

            migrationBuilder.CreateIndex(
                name: "IX_Piecework_payment_ID_profile_worker",
                table: "Piecework_payment",
                column: "ID_profile_worker");

            migrationBuilder.CreateIndex(
                name: "IX_Position_smeta_ID_catalog",
                table: "Position_smeta",
                column: "ID_catalog");

            migrationBuilder.CreateIndex(
                name: "IX_Position_smeta_ID_room_ID_adress_ID_partner",
                table: "Position_smeta",
                columns: new[] { "ID_room", "ID_adress", "ID_partner" });

            migrationBuilder.CreateIndex(
                name: "IX_Price_mat_usl_ID_catalog",
                table: "Price_mat_usl",
                column: "ID_catalog");

            migrationBuilder.CreateIndex(
                name: "IX_Price_vid_construct_ID_construct",
                table: "Price_vid_construct",
                column: "ID_construct");

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_brigada__Profile_worker",
                table: "Profile_worker",
                column: "ID_brigada");

            migrationBuilder.CreateIndex(
                name: "IX_Tipe_works__Profile_worker",
                table: "Profile_worker",
                column: "ID_tipe_works");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_vacation_ID_profile_worker",
                table: "Schedule_vacation",
                column: "ID_profile_worker");

            migrationBuilder.CreateIndex(
                name: "IX_Settlements_counterparties_Installation",
                table: "Settlements_counterparties",
                column: "ID_installation_contracts");

            migrationBuilder.CreateIndex(
                name: "IX_Settlements_counterparties_ID_partner",
                table: "Settlements_counterparties",
                column: "ID_partner");

            migrationBuilder.CreateIndex(
                name: "IX_Timesheet_ID_profile_worker",
                table: "Timesheet",
                column: "ID_profile_worker");

            migrationBuilder.CreateIndex(
                name: "IX_Work_codes__Timesheet",
                table: "Timesheet",
                column: "ID_work_code");

            migrationBuilder.CreateIndex(
                name: "IX_User_profile_ID_profile_worker",
                table: "User_profile",
                column: "ID_profile_worker");

            migrationBuilder.CreateIndex(
                name: "IX_Guide_rol__User_profile",
                table: "User_profile",
                column: "ID_rol");

            migrationBuilder.CreateIndex(
                name: "IX_Montag_to_Guide_brigada",
                table: "Zayavka_montag",
                column: "ID_brigada");

            migrationBuilder.CreateIndex(
                name: "IX_Installation_contracts__Zayavka_montag",
                table: "Zayavka_montag",
                column: "ID_installation_contracts");

            migrationBuilder.CreateIndex(
                name: "IX_Guide_adress__Zayavka_montag",
                table: "Zayavka_montag",
                columns: new[] { "ID_adress", "ID_partner" });

            migrationBuilder.CreateIndex(
                name: "IX_Counterparty_directory__Zayavka_zamer",
                table: "Zayavka_zamer",
                column: "ID_partner");

            migrationBuilder.CreateIndex(
                name: "IX_Profile_worker__Zayavka_zamer",
                table: "Zayavka_zamer",
                column: "ID_profile_worker");

            migrationBuilder.CreateIndex(
                name: "IX_Zayavka_to_Guide_status_zamer",
                table: "Zayavka_zamer",
                column: "ID_status_zamer");

            migrationBuilder.CreateIndex(
                name: "IX_Zayavka_to_Guide_adress",
                table: "Zayavka_zamer",
                columns: new[] { "ID_adress", "ID_partner" });

            migrationBuilder.AddForeignKey(
                name: "Zayavka_montag__Catalog_room",
                table: "Catalog_room",
                column: "ID_montag",
                principalTable: "Zayavka_montag",
                principalColumn: "ID_montag",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "Zayavka_zamer__Catalog_room",
                table: "Catalog_room",
                column: "ID_zayavka",
                principalTable: "Zayavka_zamer",
                principalColumn: "ID_zayavka",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "Guide_adress__Guide_room",
                table: "Catalog_room",
                columns: new[] { "ID_adress", "ID_partner" },
                principalTable: "Catalog_adress",
                principalColumns: new[] { "ID_adress", "ID_partner" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "Guide_adress__Zayavka_montag",
                table: "Zayavka_montag",
                columns: new[] { "ID_adress", "ID_partner" },
                principalTable: "Catalog_adress",
                principalColumns: new[] { "ID_adress", "ID_partner" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "Counterparty_directory__Zayavka_zamer",
                table: "Zayavka_zamer",
                column: "ID_partner",
                principalTable: "Counterparty_directory",
                principalColumn: "ID_partner",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "Zayavka_to_Guide_adress",
                table: "Zayavka_zamer",
                columns: new[] { "ID_adress", "ID_partner" },
                principalTable: "Catalog_adress",
                principalColumns: new[] { "ID_adress", "ID_partner" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "Count_products__Movement_goods",
                table: "Count_products",
                column: "ID_movement_doc",
                principalTable: "Movement_goods",
                principalColumn: "ID_movement_doc",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "Counterparty_directory__Catalog_adress",
                table: "Catalog_adress",
                column: "ID_partner",
                principalTable: "Counterparty_directory",
                principalColumn: "ID_partner",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "Counterparty_directory__Catalog_tel",
                table: "Catalog_tel_number",
                column: "ID_partner",
                principalTable: "Counterparty_directory",
                principalColumn: "ID_partner",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "Counterparty_directory__Directory",
                table: "Directory_ legal_entities",
                column: "ID_partner",
                principalTable: "Counterparty_directory",
                principalColumn: "ID_partner",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "Counterparty_directory__Directory",
                table: "Directory_ legal_entities");

            migrationBuilder.DropTable(
                name: "Catalog_cart_client");

            migrationBuilder.DropTable(
                name: "Catalog_tel_number");

            migrationBuilder.DropTable(
                name: "Count_products");

            migrationBuilder.DropTable(
                name: "E-mail_catalog");

            migrationBuilder.DropTable(
                name: "Employee_salary_handbook");

            migrationBuilder.DropTable(
                name: "Hiring_work");

            migrationBuilder.DropTable(
                name: "Payment_schedule");

            migrationBuilder.DropTable(
                name: "Piecework_payment");

            migrationBuilder.DropTable(
                name: "Position_smeta");

            migrationBuilder.DropTable(
                name: "Price_mat_usl");

            migrationBuilder.DropTable(
                name: "Price_vid_construct");

            migrationBuilder.DropTable(
                name: "Schedule_vacation");

            migrationBuilder.DropTable(
                name: "Settlements_counterparties");

            migrationBuilder.DropTable(
                name: "Timesheet");

            migrationBuilder.DropTable(
                name: "User_profile");

            migrationBuilder.DropTable(
                name: "Movement_goods");

            migrationBuilder.DropTable(
                name: "Job_positions");

            migrationBuilder.DropTable(
                name: "Catalog_room");

            migrationBuilder.DropTable(
                name: "Catalog_mat_usl");

            migrationBuilder.DropTable(
                name: "Work_codes");

            migrationBuilder.DropTable(
                name: "Guide_rol");

            migrationBuilder.DropTable(
                name: "Catalog_vid_construct");

            migrationBuilder.DropTable(
                name: "Zayavka_montag");

            migrationBuilder.DropTable(
                name: "Zayavka_zamer");

            migrationBuilder.DropTable(
                name: "Type_mat_usl");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "Installation_contracts");

            migrationBuilder.DropTable(
                name: "Profile_worker");

            migrationBuilder.DropTable(
                name: "Guide_status_zamer");

            migrationBuilder.DropTable(
                name: "Catalog_adress");

            migrationBuilder.DropTable(
                name: "Catalog_brigada");

            migrationBuilder.DropTable(
                name: "Tipe_works");

            migrationBuilder.DropTable(
                name: "Counterparty_directory");

            migrationBuilder.DropTable(
                name: "Customer_directory");

            migrationBuilder.DropTable(
                name: "Directory_ legal_entities");
        }
    }
}
