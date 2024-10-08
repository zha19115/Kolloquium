﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kolloquium.Migrations
{
    /// <inheritdoc />
    public partial class ConnectDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    c_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    c_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    c_phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    c_email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    c_newsletter = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.c_id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    m_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    m_title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    m_genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    m_description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    m_releaseDate = table.Column<DateOnly>(type: "date", nullable: false),
                    m_showTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.m_id);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    t_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    t_seat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    m_id = table.Column<int>(type: "int", nullable: false),
                    c_id = table.Column<int>(type: "int", nullable: false),
                    Moviem_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Customerc_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.t_id);
                    table.ForeignKey(
                        name: "FK_Tickets_Customers_Customerc_id",
                        column: x => x.Customerc_id,
                        principalTable: "Customers",
                        principalColumn: "c_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Movies_Moviem_id",
                        column: x => x.Moviem_id,
                        principalTable: "Movies",
                        principalColumn: "m_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_Customerc_id",
                table: "Tickets",
                column: "Customerc_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_Moviem_id",
                table: "Tickets",
                column: "Moviem_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
