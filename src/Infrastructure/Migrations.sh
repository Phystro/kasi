echo "Initial Create Migrations"
echo ""

dotnet ef migrations add InitialCreate -o ./Persistence/Migrations/ --startup-project ../Presentation/Web/Server/Kasi.Web.Server.csproj

echo ""
echo "DONE"
echo ""

echo "Database Update"
echo ""

dotnet ef database update --startup-project ../Presentation/Web/Server/Kasi.Web.Server.csproj

echo ""
echo "DONE"

