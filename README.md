# Olve.Trie

## Overview


## Introduction


## Benchmarks

Benchmarks are a comparison between:

- `Olve` - This library
- `KTrie` - [kpol/trie](https://github.com/kpol/trie)

### Initialization
<!-- BENCHMARK_ID: "construct-trie" -->

Benchmark run 2025-01-22 13.13.02

| Method | WordCount | Mean | Error | StdDev | Median | Ratio | RatioSD | Gen0 | Gen1 | Gen2 | Allocated | Alloc Ratio |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| KTrie | 300 | 111.8 μs | 14.14 μs | 41.69 μs | 88.25 μs | 1.11 | 0.52 | - | - | - | 150.11 KB | 1.00 |
| Olve_NaiveArrayTrie | 300 | 151.7 μs | 7.12 μs | 20.76 μs | 158.75 μs | 1.51 | 0.47 | - | - | - | 165.47 KB | 1.10 |
| Olve_NaiveArrayTrie | 10000 | 2,581.8 μs | 57.78 μs | 168.55 μs | 2,571.20 μs | 0.89 | 0.06 | - | - | - | 4211.58 KB | 1.09 |
| KTrie | 10000 | 2,916.7 μs | 55.35 μs | 49.07 μs | 2,910.70 μs | 1.00 | 0.02 | - | - | - | 3869.32 KB | 1.00 |
| Olve_NaiveArrayTrie | 300000 | 204,077.9 μs | 4,058.09 μs | 10,106.06 μs | 204,323.50 μs | 0.73 | 0.13 | 4000.0000 | 3000.0000 | 1000.0000 | 67239.08 KB | 0.97 |
| KTrie | 300000 | 288,810.9 μs | 15,362.73 μs | 45,297.35 μs | 305,420.40 μs | 1.03 | 0.25 | 4000.0000 | 3000.0000 | 1000.0000 | 69322.47 KB | 1.00 |


*[source](https://github.com/OliverVea/Olve.Trie/blob/a1eadffddf15961525d03a1edc29a1ba49a23477/Olve.Trie.Benchmarks/Benchmarks/ConstructTrieBenchmark.cs)*
<!-- BENCHMARK_END -->

### Prefix Match
<!-- BENCHMARK_ID: "list-with-prefix" -->

Benchmark run 2025-01-22 13.14.59

| Method | WordCount | Mean | Error | StdDev | Median | Ratio | RatioSD | Allocated | Alloc Ratio |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| Olve_NaiveArrayTrie_ListWithPrefix | 300 | 21.23 μs | 1.399 μs | 3.783 μs | 21.00 μs | 1.03 | 0.27 | 14.94 KB | 1.00 |
| Olve_NaiveArrayTrie_EnumerateWithPrefix | 300 | 31.45 μs | 5.095 μs | 14.701 μs | 24.15 μs | 1.53 | 0.78 | 17.32 KB | 1.16 |
| KTrie_StartsWith | 300 | 38.64 μs | 3.912 μs | 11.473 μs | 37.15 μs | 1.88 | 0.67 | 7.2 KB | 0.48 |
| KTrie_StartsWith | 10000 | 149.75 μs | 3.914 μs | 10.447 μs | 147.80 μs | 0.82 | 0.14 | 52.63 KB | 0.17 |
| Olve_NaiveArrayTrie_ListWithPrefix | 10000 | 188.28 μs | 11.838 μs | 33.196 μs | 179.40 μs | 1.03 | 0.24 | 306.13 KB | 1.00 |
| Olve_NaiveArrayTrie_EnumerateWithPrefix | 10000 | 230.60 μs | 11.616 μs | 32.953 μs | 231.70 μs | 1.26 | 0.27 | 313.58 KB | 1.02 |
| KTrie_StartsWith | 300000 | 6,017.37 μs | 114.498 μs | 160.510 μs | 6,006.00 μs | 0.79 | 0.04 | 983.35 KB | 0.20 |
| Olve_NaiveArrayTrie_ListWithPrefix | 300000 | 7,656.72 μs | 151.389 μs | 319.332 μs | 7,715.75 μs | 1.00 | 0.06 | 4826.84 KB | 1.00 |
| Olve_NaiveArrayTrie_EnumerateWithPrefix | 300000 | 7,708.23 μs | 68.620 μs | 57.301 μs | 7,724.00 μs | 1.01 | 0.04 | 4840.7 KB | 1.00 |


*[source](https://github.com/OliverVea/Olve.Trie/blob/a1eadffddf15961525d03a1edc29a1ba49a23477/Olve.Trie.Benchmarks/Benchmarks/ListWithPrefixBenchmark.cs)*
<!-- BENCHMARK_END -->
