# Configuration
$server = "localhost"
$database = "myDatabase"
$user = "sa"
$password = "yourStrong(!)Password"

# Paths to scripts
$schemaScript = "./Create Scripts/00_schema.sql"
$indexScript  = "./Create Scripts/01_indexes.sql"
$seedScript   = "./Create Scripts/02_seed.sql"

# Ensure sqlcmd is available
if (-not (Get-Command sqlcmd -ErrorAction SilentlyContinue)) {
    Write-Error "sqlcmd is not installed. Please install the mssql-tools."
    exit 1
}

## Drop existing database & Create a new database
Write-Host "Dropping existing database and creating fresh database..."
sqlcmd -S $server -d $database -U $user -P $password -Q "
USE master;
GO
IF DB_ID('$database') IS NOT NULL
BEGIN
    ALTER DATABASE [$database] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [$database];
    CREATE DATABASE [$database];
END
GO"


# Run scripts
Write-Host "Running schema script..."
sqlcmd -S $server -d $database -U $user -P $password -i $schemaScript
if ($LASTEXITCODE -ne 0) { Write-Error "Schema script failed."; exit 1 }

Write-Host "Running index script..."
sqlcmd -S $server -d $database -U $user -P $password -i $indexScript
if ($LASTEXITCODE -ne 0) { Write-Error "Index script failed."; exit 1 }

Write-Host "Running seed script..."
sqlcmd -S $server -d $database -U $user -P $password -i $seedScript
if ($LASTEXITCODE -ne 0) { Write-Error "Seed script failed."; exit 1 }

Write-Host "Database prepared successfully ✅ "
