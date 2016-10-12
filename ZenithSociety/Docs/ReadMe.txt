Enable-Migrations -ContextProjectName ZenithDataLib -ContextTypeName ZenithSocietyContext

Add-Migration -ConfigurationTypeName ZenithSociety.Migrations.Configuration "FirstMigration"

Update-Database -ConfigurationTypeName ZenithSociety.Migrations.Configuration

