using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LinqToDB.SqlQuery
{
	using LinqToDB.Extensions;
	using System.Reflection;

	public static class ReservedWords
	{
		private static readonly HashSet<string> _reservedWordsAll = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
		private static readonly HashSet<string> _reservedWordsPostgres = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
		private static readonly HashSet<string> _reservedWordsOracle = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
		private static readonly HashSet<string> _reservedWordsFirebird = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
		private static readonly ConcurrentDictionary<string, HashSet<string>> _reservedWords = new ConcurrentDictionary<string, HashSet<string>>(StringComparer.OrdinalIgnoreCase);

		static ReservedWords()
		{
			_reservedWords[string.Empty] = _reservedWordsAll;
			_reservedWords[ProviderName.PostgreSQL] = _reservedWordsPostgres;
			_reservedWords[ProviderName.PostgreSQL92] = _reservedWordsPostgres;
			_reservedWords[ProviderName.PostgreSQL93] = _reservedWordsPostgres;
			_reservedWords[ProviderName.PostgreSQL95] = _reservedWordsPostgres;
			_reservedWords[ProviderName.Oracle] = _reservedWordsOracle;
			_reservedWords[ProviderName.OracleManaged] = _reservedWordsOracle;
			_reservedWords[ProviderName.OracleNative] = _reservedWordsOracle;
			_reservedWords[ProviderName.Firebird] = _reservedWordsFirebird;

			var assembly = typeof(SelectQuery).AssemblyEx();
			LoadReservedWords("ReservedWords.txt", assembly, _reservedWordsAll);
			LoadReservedWords("ReservedWordsPostgres.txt", assembly, _reservedWordsPostgres, _reservedWordsAll);
			LoadReservedWords("ReservedWordsOracle.txt", assembly, _reservedWordsOracle, _reservedWordsAll);
			LoadReservedWords("ReservedWordsFirebird.txt", assembly, _reservedWordsFirebird);
		}

		private static void LoadReservedWords(string endwith, Assembly asm, params HashSet<string>[] sets)
		{
			var name = asm.GetManifestResourceNames().Single(_ => _.EndsWith(endwith));
			using (var stream = asm.GetManifestResourceStream(name))
			{
				using (var reader = new StreamReader(stream))
				{
					var s = string.Empty;
					while ((s = reader.ReadLine()) != null)
					{
						foreach (var set in sets)
						{
							set.Add(s);
						}
					}
				}
			}
		}

		public static bool IsReserved(string word, string providerName = null)
		{
			if (string.IsNullOrEmpty(providerName))
			{
				return _reservedWordsAll.Contains(word);
			}

			if (!_reservedWords.TryGetValue(providerName, out var words))
			{
				words = _reservedWordsAll;
			}

			return words.Contains(word);
		}

		public static void Add(string word, string providerName = null)
		{
			lock (_reservedWordsAll)
			{
				_reservedWordsAll.Add(word);
			}

			if (string.IsNullOrEmpty(providerName))
			{
				return;
			}

			var set = _reservedWords.GetOrAdd(providerName, new HashSet<string>(StringComparer.OrdinalIgnoreCase));
			lock (set)
			{
				set.Add(word);
			}
		}
	}
}
