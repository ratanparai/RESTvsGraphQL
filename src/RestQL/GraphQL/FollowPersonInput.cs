using System;

namespace RestQL.GraphQL
{
    public record FollowPersonInput(
        Guid FollowerId, 
        Guid FollowedId);
}