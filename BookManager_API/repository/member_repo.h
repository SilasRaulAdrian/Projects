#pragma once

#include <vector>

#include "i_member_repo.h"
#include "../db/database_manager.h"
#include "../domain/member.h"

class MemberRepo : public IMemberRepo {
private:
    Database &db;

public:
    MemberRepo(Database &db);
    ~MemberRepo();

    void addMember(const Member &member) override;
    std::vector<Member> getMembers() override;
    void deleteMember(int id) override;
    Member getMemberById(int id);
};