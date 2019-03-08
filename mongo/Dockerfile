FROM mongo:4.0-xenial

WORKDIR /docker-entrypoint-initdb.d

COPY ./init .

WORKDIR /etc/mongo/
COPY ./mongod.conf .

EXPOSE 27017
CMD ["mongod", "--bind_ip_all","--config","/etc/mongo/mongod.conf"]