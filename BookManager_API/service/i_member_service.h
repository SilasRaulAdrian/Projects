#pragma once

#include <vector>

#include "../domain/member.h"

class IMemberService {
public:
    ~IMemberService() = default;

    virtual void createMember(const Member& member) = 0;
    virtual std::vector<Member> listAllMembers() = 0;
    virtual void deleteMember(int id) = 0;
    virtual Member getMemberById(int id) = 0;
};
