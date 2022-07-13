using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RailWayInfrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Passengers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    BloodGroup = table.Column<int>(type: "INTEGER", nullable: true),
                    NOK_PhoneNo = table.Column<string>(type: "TEXT", nullable: false),
                    NOK_Name = table.Column<string>(type: "TEXT", nullable: false),
                    NOK_Address = table.Column<string>(type: "TEXT", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Gender = table.Column<int>(type: "INTEGER", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNo = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "BLOB", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "BLOB", nullable: false),
                    IsLock = table.Column<bool>(type: "INTEGER", nullable: false),
                    NTry = table.Column<int>(type: "INTEGER", nullable: false),
                    LastLogin = table.Column<DateTime>(type: "TEXT", nullable: false),
                    RefreshToken = table.Column<string>(type: "TEXT", nullable: true),
                    TokenCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TokenExpires = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passengers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Staffs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    StaffId = table.Column<string>(type: "TEXT", nullable: false),
                    Role = table.Column<string>(type: "TEXT", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Gender = table.Column<int>(type: "INTEGER", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNo = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "BLOB", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "BLOB", nullable: false),
                    IsLock = table.Column<bool>(type: "INTEGER", nullable: false),
                    NTry = table.Column<int>(type: "INTEGER", nullable: false),
                    LastLogin = table.Column<DateTime>(type: "TEXT", nullable: false),
                    RefreshToken = table.Column<string>(type: "TEXT", nullable: true),
                    TokenCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TokenExpires = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tracks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    TrackName = table.Column<string>(type: "TEXT", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    PassengerId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    TimeOfPayment = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsAprove = table.Column<bool>(type: "INTEGER", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Passengers_PassengerId",
                        column: x => x.PassengerId,
                        principalTable: "Passengers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    StationName = table.Column<string>(type: "TEXT", nullable: false),
                    TrainArriverTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Index = table.Column<int>(type: "INTEGER", nullable: false),
                    TrackId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Location = table.Column<string>(type: "TEXT", nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    StationAdminId = table.Column<Guid>(type: "TEXT", nullable: false),
                    DepartingTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    StationPhoneNo = table.Column<string>(type: "TEXT", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stations_Staffs_StationAdminId",
                        column: x => x.StationAdminId,
                        principalTable: "Staffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stations_Tracks_TrackId",
                        column: x => x.TrackId,
                        principalTable: "Tracks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trains",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Capacity = table.Column<int>(type: "INTEGER", nullable: false),
                    TrailEngineerId = table.Column<Guid>(type: "TEXT", nullable: false),
                    TrackId = table.Column<Guid>(type: "TEXT", nullable: false),
                    DepartedStationId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Delay = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    IsOnTrack = table.Column<bool>(type: "INTEGER", nullable: false),
                    TripDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    NTransitPassenge = table.Column<int>(type: "INTEGER", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trains", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trains_Staffs_TrailEngineerId",
                        column: x => x.TrailEngineerId,
                        principalTable: "Staffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trains_Stations_DepartedStationId",
                        column: x => x.DepartedStationId,
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trains_Tracks_TrackId",
                        column: x => x.TrackId,
                        principalTable: "Tracks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookedTrips",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    PickupStationId = table.Column<Guid>(type: "TEXT", nullable: false),
                    DestinationStationId = table.Column<Guid>(type: "TEXT", nullable: false),
                    TripDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SettledTrip = table.Column<bool>(type: "INTEGER", nullable: false),
                    PassengerId = table.Column<Guid>(type: "TEXT", nullable: false),
                    PaymentId = table.Column<Guid>(type: "TEXT", nullable: false),
                    TrainId = table.Column<Guid>(type: "TEXT", nullable: false),
                    NumberOfSeat = table.Column<int>(type: "INTEGER", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookedTrips", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookedTrips_Passengers_PassengerId",
                        column: x => x.PassengerId,
                        principalTable: "Passengers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookedTrips_Payments_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookedTrips_Stations_DestinationStationId",
                        column: x => x.DestinationStationId,
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookedTrips_Stations_PickupStationId",
                        column: x => x.PickupStationId,
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookedTrips_Trains_TrainId",
                        column: x => x.TrainId,
                        principalTable: "Trains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookedTrips_DestinationStationId",
                table: "BookedTrips",
                column: "DestinationStationId");

            migrationBuilder.CreateIndex(
                name: "IX_BookedTrips_PassengerId",
                table: "BookedTrips",
                column: "PassengerId");

            migrationBuilder.CreateIndex(
                name: "IX_BookedTrips_PaymentId",
                table: "BookedTrips",
                column: "PaymentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookedTrips_PickupStationId",
                table: "BookedTrips",
                column: "PickupStationId");

            migrationBuilder.CreateIndex(
                name: "IX_BookedTrips_TrainId",
                table: "BookedTrips",
                column: "TrainId");

            migrationBuilder.CreateIndex(
                name: "IX_Passengers_Email",
                table: "Passengers",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_PassengerId",
                table: "Payments",
                column: "PassengerId");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_Email",
                table: "Staffs",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stations_StationAdminId",
                table: "Stations",
                column: "StationAdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Stations_TrackId",
                table: "Stations",
                column: "TrackId");

            migrationBuilder.CreateIndex(
                name: "IX_Trains_DepartedStationId",
                table: "Trains",
                column: "DepartedStationId");

            migrationBuilder.CreateIndex(
                name: "IX_Trains_TrackId",
                table: "Trains",
                column: "TrackId");

            migrationBuilder.CreateIndex(
                name: "IX_Trains_TrailEngineerId",
                table: "Trains",
                column: "TrailEngineerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookedTrips");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Trains");

            migrationBuilder.DropTable(
                name: "Passengers");

            migrationBuilder.DropTable(
                name: "Stations");

            migrationBuilder.DropTable(
                name: "Staffs");

            migrationBuilder.DropTable(
                name: "Tracks");
        }
    }
}
