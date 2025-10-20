namespace Board.Contracts.Base
{
    public interface IPagination
    {
        /// <summary>
        /// Номер страницы
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Сколько взять)
        /// </summary>
        public int Take { get; set; }
    }
}
