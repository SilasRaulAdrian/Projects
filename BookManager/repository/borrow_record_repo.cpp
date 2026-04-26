#include "borrow_record_repo.h"

BorrowRecordRepo::BorrowRecordRepo(Database &db) : db(db) {}
BorrowRecordRepo::~BorrowRecordRepo() = default;

void BorrowRecordRepo::addBorrowRecord(const BorrowRecord &record) {
    pqxx::connection &conn = db.getConnection();
    pqxx::work txn(conn);

    txn.exec_params(
        "INSERT INTO borrow_records (book_id, member_id, borrow_date) VALUES ($1, $2, $3)",
        record.getBookId(),
        record.getMemberId(),
        record.getBorrowDate()
    );

    txn.commit();
}

std::vector<BorrowRecord> BorrowRecordRepo::getBorrowRecords() {
    pqxx::connection &conn = db.getConnection();
    pqxx::work txn(conn);

    pqxx::result res = txn.exec("SELECT * FROM borrow_records");

    std::vector<BorrowRecord> records;

    for (const auto &row : res) {
        records.emplace_back(
            row["id"].as<int>(),
            row["book_id"].as<int>(),
            row["member_id"].as<int>(),
            row["borrow_date"].as<std::string>()
        );
    }

    txn.commit();
    return records;
}

void BorrowRecordRepo::deleteBorrowRecord(int id) {
    pqxx::connection &conn = db.getConnection();
    pqxx::work txn(conn);

    txn.exec_params(
        "DELETE FROM borrow_records WHERE id = $1",
        id
    );

    txn.commit();
}

BorrowRecord BorrowRecordRepo::getRecordById(int id) {
    pqxx::connection &conn = db.getConnection();
    pqxx::work txn(conn);

    pqxx::result res = txn.exec_params(
        "SELECT * FROM borrow_records WHERE id = $1",
        id
    );

    const auto &row = res[0];
    BorrowRecord record(
        row["id"].as<int>(),
        row["book_id"].as<int>(),
        row["member_id"].as<int>(),
        row["borrow_date"].as<std::string>()
    );

    txn.commit();

    return record;
}