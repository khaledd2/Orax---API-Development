﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class UserRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"INSERT INTO [dbo].[AspNetRoles] VALUES ('{Guid.NewGuid()}', 'User', 'USER', '{Guid.NewGuid()}')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"DELETE FROM [dbo].[AspNetRoles] WHERE Name = 'User'");
        }
    }
}
