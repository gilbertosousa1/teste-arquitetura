FROM mcr.microsoft.com/mssql/server:2022-latest

USER root

COPY init-db.sql /usr/src/app/init-db.sql
COPY entrypoint.sh /usr/src/app/entrypoint.sh
RUN chmod +x /usr/src/app/entrypoint.sh

USER mssql

ENTRYPOINT ["/usr/src/app/entrypoint.sh"]