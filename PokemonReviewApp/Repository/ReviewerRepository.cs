﻿using Microsoft.EntityFrameworkCore;
using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
    public class ReviewerRepository : IReviewerRepository
    {
        private readonly DataContext _context;

        public ReviewerRepository(DataContext context)
        {
            _context = context;
        }
        Reviewer IReviewerRepository.GetReviewer(int reviewerId)
        {
            return _context.Reviewers.Where(r => r.Id == reviewerId).Include(e => e.Reviews).FirstOrDefault();
            // what <include> does here is include the related entity i.e instead of 
            // returning nulls as the realted entity itll return the values
        }

        ICollection<Reviewer> IReviewerRepository.GetReviewers()
        {
            return _context.Reviewers.OrderBy(r => r.Id).ToList();
        }

        ICollection<Review> IReviewerRepository.GetReviewsByReviewer(int reviewerId)
        {
            return _context.Reviews.Where(r => r.Reviewer.Id == reviewerId).ToList();
        }

        bool IReviewerRepository.ReviewerExists(int reviewerId)
        {
            return _context.Reviewers.Any(r => r.Id == reviewerId);
        }
    }
}
