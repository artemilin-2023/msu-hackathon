using System.Reflection.Metadata.Ecma335;

namespace WorksShare.API.Contracts
{
    public static class RequestChecker
    {
        public static bool IsOkay(this PostWorkRequest request) 
            => request != null && request.Hierarchy != null
            && request.Hierarchy.WorkType != null && request.Hierarchy.Subject != null
            && !string.IsNullOrEmpty(request.Name)
            && request.Hierarchy.Course > 0 && request.Hierarchy.Course <= 6
            && request.Files != null && request.Files.Count > 0;
    }
}
