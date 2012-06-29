function UpdateForumAndThreadNumbers(forumID, threadID) {
    var ForumService = new TGExpressCMSServices.ForumService();
    ForumService.UpdateForumAndThreadNumbers(forumID, threadID);
}
function UpdateForumAndThreadForPosts(PostsIDs) {
    var ForumService = new TGExpressCMSServices.ForumService();
    ForumService.UpdateForumAndThreadForPosts(PostsIDs);
}
function UpdateForumForThreads(ThreadIDs) {
    
    var ForumService = new TGExpressCMSServices.ForumService();
    ForumService.UpdateForumForThreads(ThreadIDs);
}
function UpdateForumViews(ForumIDs) {
    var ForumService = new TGExpressCMSServices.ForumService();
    ForumService.UpdateForumViews(ForumIDs);
}
function UpdateThreadViews(ThreadIDs) {
    var ForumService = new TGExpressCMSServices.ForumService();
    ForumService.UpdateThreadViews(ThreadIDs);
}