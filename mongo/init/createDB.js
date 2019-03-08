db = new Mongo().getDB("admin");

var dbName = "hotels_db";

db.createUser(
  {
    user: "admin",
    pwd: "admin",
    roles: [{ role: "userAdminAnyDatabase", db: "admin" }, "readWriteAnyDatabase"]
  }
);

db.createUser(
  {
    user: "service",
    pwd: "service",
    roles: [{ role: "readWrite", db: dbName }]
  }
);

// Create profileName index
db = new Mongo().getDB(dbName);
