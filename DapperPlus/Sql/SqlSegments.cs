using System;
using System.Text.RegularExpressions;

namespace DapperPlus.Sql
{
    public class SqlSegments
    {
        private static readonly Regex rexSelect;
        private static readonly Regex rexOrderBy;

        static SqlSegments()
        {
            rexSelect = new Regex(@"^\s*SELECT\s+(.+?)\sFROM\s", RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Compiled);
            rexOrderBy = new Regex(@"\s+ORDER\s+BY\s+([^\s]+(?:\s+ASC|\s+DESC)?)\s*$", RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Compiled);
        }

        /// <summary>
        /// Gets or sets the select part sql.
        /// eg:select distinct id,name
        /// </summary>
        /// <value>The select.</value>
        public string Select
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the sql body part.
        /// from 与 order by 之间的内容
        /// eg: user where Id = 45
        /// </summary>
        /// <value>The body.</value>
        public string Body
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the sql order by part.
        /// eg: createTime asc
        /// </summary>
        /// <value>The order by.</value>
        public string OrderBy
        {
            get;
            set;
        }

        /// <summary>
        /// Parse the specified sql.
        /// </summary>
        /// <returns>SqlSegments</returns>
        /// <param name="sql">Sql.</param>
        /// <exception cref="ArgumentNullException,ArgumentException"/>
        public static SqlSegments Parse(string sql)
        {
            if (string.IsNullOrEmpty(sql))
            {
                throw new ArgumentNullException(nameof(sql), "Sql must not be null or empty");
            }

            SqlSegments segments = new SqlSegments();
            Match result = rexSelect.Match(sql);
            if (!result.Success)
            {
                throw new ArgumentException("Unable parse sql for select");
            }

            segments.Select = result.Groups[1].Value;
            sql = sql.Substring(result.Length);
            result = rexOrderBy.Match(sql);
            if (result.Success)
            {
                sql = sql.Substring(0, result.Index);
                segments.OrderBy = result.Groups[1].Value;
            }
            segments.Body = sql;

            return segments;
        }
    }
}
