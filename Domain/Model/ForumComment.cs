﻿using BookingApp.Serializer;
using System;

namespace BookingApp.Domain.Model
{
    public class ForumComment : ISerializable
    {
        private int _forumId;
        private int _commentId;

        public int ForumId { get => _forumId; set => _forumId = value; }
        public int CommentId { get => _commentId; set => _commentId = value; }

        public ForumComment(int forumId, int commentId)
        {
            ForumId = forumId;
            CommentId = commentId;
        }
        public ForumComment()
        {
        }
        public string[] ToCSV()
        {
            string[] csvValues = {
                ForumId.ToString(),
                CommentId.ToString(),
            };
            return csvValues;
        }
        public void FromCSV(string[] values)
        {
            ForumId = Convert.ToInt32(values[0]);
            CommentId = Convert.ToInt32(values[1]);
        }
    }
}
