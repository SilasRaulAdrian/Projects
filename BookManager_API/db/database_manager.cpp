#include "database_manager.h"
#include <iostream>

Database::Database(const std::string& connStr)
    : connectionString(connStr) {}

Database::~Database() {
    disconnect();
}

bool Database::connect() {
    try {
        conn = std::make_unique<pqxx::connection>(connectionString);

        if (conn->is_open()) {
            std::cout << "Connected to PostgreSQL\n";
            return true;
        }
    } catch (const std::exception& e) {
        std::cerr << "Connection failed: " << e.what() << std::endl;
    }

    return false;
}

void Database::disconnect() {
    if (conn && conn->is_open()) {
        conn->close();
    }
}

bool Database::isConnected() const {
    return conn && conn->is_open();
}

pqxx::connection& Database::getConnection() {
    if (!isConnected()) {
        throw std::runtime_error("Database not connected");
    }
    return *conn;
}