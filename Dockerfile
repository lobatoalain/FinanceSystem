FROM mcr.microsoft.com/mssql/server

ENV SA_PASSWORD=TesteUneC0nt@Alain
ENV ACCEPT_EULA=Y

# Copie o script de inicialização para o container
COPY setup.sql /usr/src/app/

# Comando para iniciar o SQL Server e executar o script
CMD /opt/mssql/bin/sqlservr & sleep 30; /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P TesteUneC0nt@Alain -d master -i /usr/src/app/init.sql
