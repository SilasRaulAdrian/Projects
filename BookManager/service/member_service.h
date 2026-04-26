#pragma once

#include "i_member_service.h"
#include "../repository/member_repo.h"

class MemberService : public IMemberService {
private:
    IMemberRepo &repo;

public:
    MemberService(IMemberRepo &repo);
    ~MemberService();

    void createMember(const Member& member) override;
    std::vector<Member> listAllMembers() override;
    void deleteMember(int id) override;
    Member getMemberById(int id) override;
};