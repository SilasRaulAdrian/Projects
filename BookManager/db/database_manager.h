#pragma once

#include <string>
#include <memory>
#include <pqxx/pqxx>

class Database {
private:
    std::string connectionString;
    std::unique_ptr<pqxx::connection> conn;

public:
    explicit Database(const std::string& connStr);
    ~Database();

    bool connect();
    void disconnect();

    bool isConnected() const;

    pqxx::connection& getConnection();
};