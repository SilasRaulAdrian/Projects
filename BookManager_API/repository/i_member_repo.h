#pragma once

#include <vector>

#include "../domain/member.h"

class IMemberRepo {
public:
    ~IMemberRepo() = default;

    virtual void addMember(const Member &member) = 0;
    virtual std::vector<Member> getMembers() = 0;
    virtual void deleteMember(int id) = 0;
    virtual Member getMemberById(int id) = 0;
};