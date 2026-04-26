#include "member_service.h"

MemberService::MemberService(IMemberRepo &repo) : repo(repo) {}
MemberService::~MemberService() = default;

void MemberService::createMember(const Member &member) {
    if (member.getName().empty()) {
        throw std::runtime_error("Invalid member data. Name cannot be empty.");
    }

    std::vector<Member> members = repo.getMembers();
    auto it = std::find_if(members.begin(), members.end(), [&member](const Member &m) {
        return m.getId() == member.getId();
    });

    if (it != members.end()) {
        throw std::runtime_error("Member with ID " + std::to_string(member.getId()) + " already exists.");
    }

    repo.addMember(member);
}

std::vector<Member> MemberService::listAllMembers() {
    return repo.getMembers();
}

void MemberService::deleteMember(int id) {
    if (id <= 0) {
        throw std::runtime_error("Invalid member ID. ID must be positive.");
    }

    std::vector<Member> members = repo.getMembers();
    auto it = std::find_if(members.begin(), members.end(), [id](const Member &m) {
        return m.getId() == id;
    });

    if (it == members.end()) {
        throw std::runtime_error("No member found with the given ID.");
    }

    repo.deleteMember(id);
}

Member MemberService::getMemberById(int id) {
    if (id <= 0 || id > repo.getMembers().size()) {
        throw std::runtime_error("Invalid member ID. ID must be positive.");
    }

    return repo.getMemberById(id);
}