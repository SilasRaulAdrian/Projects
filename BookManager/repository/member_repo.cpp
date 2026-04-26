#include "member_repo.h"

MemberRepo::MemberRepo(Database &db) : db(db) {}
MemberRepo::~MemberRepo() = default;

void MemberRepo::addMember(const Member &member) {
    pqxx::connection &conn = db.getConnection();
    pqxx::work txn(conn);

    txn.exec_params(
        "INSERT INTO members (name) VALUES ($1)",
        member.getName()
    );

    txn.commit();
}

std::vector<Member> MemberRepo::getMembers() {
    pqxx::connection &conn = db.getConnection();
    pqxx::work txn(conn);

    pqxx::result res = txn.exec("SELECT * FROM members");

    std::vector<Member> members;

    for (const auto& row : res) {
        members.emplace_back(
            row["id"].as<int>(),
            row["name"].as<std::string>()
        );
    }

    txn.commit();
    return members;
}

void MemberRepo::deleteMember(int id) {
    pqxx::connection &conn = db.getConnection();
    pqxx::work txn(conn);

    txn.exec_params(
        "DELETE FROM members WHERE id = $1",
        id
    );

    txn.commit();
}

Member MemberRepo::getMemberById(int id) {
    pqxx::connection &conn = db.getConnection();
    pqxx::work txn(conn);

    pqxx::result res = txn.exec_params(
        "SELECT * FROM members WHERE id = $1",
        id
    );

    const auto &row = res[0];
    Member member(
        row["id"].as<int>(),
        row["name"].as<std::string>()
    );

    txn.commit();

    return member;
}
