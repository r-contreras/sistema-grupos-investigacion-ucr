
FROM mcr.microsoft.com/azure-sql-edge:latest
ENV ACCEPT_EULA=Y
ENV MSSQL_PID=Developer
LABEL source=sqldbproject-database_researchrepository
RUN mkdir -p /opt/sqlproject
COPY .mssql/commands/ /opt/commands
RUN ["/bin/bash", "/opt/commands/start.sh"]
