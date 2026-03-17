import { query } from "./_generated/server";
import { v } from "convex/values";
import { counts } from "./counter";
import { voteKey } from "./vote";

// How many recent posts to fetch in the past day, max
const LEADERBOARD_LIMIT = 1000;

export const getTopPosts = query({
    args: { limit: v.optional(v.number()) },
    handler: async (ctx, args) => {
        const limit = args.limit ?? 10;

        const now = new Date();
        const oneDayAgo = new Date(now.getTime() - 24 * 60 * 60 * 1000);
        const posts = await ctx.db
            .query("post")
            .withIndex("by_creation_time", (q) =>
                q.gt("_creationTime", oneDayAgo.getTime())
            )
            .order("desc")
            .take(LEADERBOARD_LIMIT);

        const postsWithScores = await Promise.all(
            posts.map(async (post) => {
                const upvotes = await counts.count(ctx, voteKey(post._id, "upvote"));
                const downvotes = await counts.count(ctx, voteKey(post._id, "downvote"));

                const author = await ctx.db.get(post.authorId);
                const subreddit = await ctx.db.get(post.subreddit);

                return {
                    ...post,
                    score: upvotes - downvotes,
                    upvotes,
                    downvotes,
                    author: { username: author?.username ?? "[deleted]" },
                    subreddit: { name: subreddit?.name ?? "[deleted]" },
                };
            })
        )

        return postsWithScores.sort((a, b) => b.score - a.score).slice(0, limit);
    }
})