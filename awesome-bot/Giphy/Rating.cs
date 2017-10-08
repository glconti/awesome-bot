namespace awesome_bot.Giphy
{
    public sealed class Rating
    {
        /// <summary>
        ///     Restricted
        ///     Under 17 requires accompanying parent or adult guardian.Contains some adult material.Parents are urged to learn
        ///     more about the film before taking their young children with them.
        /// </summary>
        public static Rating R = new Rating("R");

        /// <summary>
        ///     General Audiences
        ///     All ages admitted.Nothing that would offend parents for viewing by children.
        /// </summary>
        public static Rating G = new Rating("G");

        /// <summary>
        ///     All Children
        ///     Appropriate for all children.
        /// </summary>
        public static Rating Y = new Rating("Y");

        /// <summary>
        ///     Parental Guidance Suggested
        ///     Some material may not be suitable for children.Parents urged to give "parental guidance". May contain some material
        ///     parents might not like for their young children.
        /// </summary>
        public static Rating PG = new Rating("PG");

        /// <summary>
        ///     Parents Strongly Cautioned
        ///     Some material may be inappropriate for children under 13. Parents are urged to be cautious.Some material may be
        ///     inappropriate for pre-teenagers.
        /// </summary>
        public static Rating PG13 = new Rating("PG-13");

        private readonly string _rating;

        private Rating(string rating)
        {
            _rating = rating;
        }

        public override string ToString() => _rating;
    }
}