# MIS.IntegrationTests
Щоб тести працювали з заданою connection string, необхідно налаштувати SQL Server Docker контейнер за допомогою наступної bash-команди:
> docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=P@ssword123" \
   -p 14331:1433 --name sql_test --hostname sql_test \
   -d mcr.microsoft.com/mssql/server:2022-latest
