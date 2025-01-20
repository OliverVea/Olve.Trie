# Olve.Trie

## Overview


## Introduction


## Benchmarks

Benchmarks are a comparison between:

- `Olve` - This library
- `KTrie` - [kpol/trie](https://github.com/kpol/trie)

### Initialization
<!-- BENCHMARK_ID: "construct-trie" -->

Benchmark run 2025-01-20 14.59.16

| Method | WordCount | Mean | Error | StdDev | Ratio | RatioSD | Gen0 | Gen1 | Gen2 | Allocated | Alloc Ratio |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| KTrie | 300 | 92.54 μs | 3.387 μs | 8.923 μs | 1.01 | 0.13 | - | - | - | 150.11 KB | 1.00 |
| Olve | 300 | 365.98 μs | 7.077 μs | 19.253 μs | 3.99 | 0.41 | - | - | - | 800.3 KB | 5.33 |
| KTrie | 10000 | 2,614.24 μs | 58.645 μs | 171.071 μs | 1.01 | 0.11 | - | - | - | 3869.32 KB | 1.00 |
| Olve | 10000 | 7,001.81 μs | 138.161 μs | 269.472 μs | 2.69 | 0.25 | 1000.0000 | - | - | 20298.47 KB | 5.25 |
| KTrie | 300000 | 221,452.27 μs | 4,422.978 μs | 7,746.491 μs | 1.00 | 0.05 | 4000.0000 | 3000.0000 | 1000.0000 | 69322.13 KB | 1.00 |
| Olve | 300000 | 717,817.23 μs | 14,259.600 μs | 30,388.372 μs | 3.25 | 0.18 | 20000.0000 | 19000.0000 | 3000.0000 | 325363.39 KB | 4.69 |


*[source](https://github.com/OliverVea/Olve.Trie/blob/638fe352a69452f957c0bc69c4807c7dc3c143ea/Olve.Trie.Benchmarks/Benchmarks/ConstructTrieBenchmark.cs)*
<!-- BENCHMARK_END -->

### Prefix Match
<!-- BENCHMARK_ID: "prefix-match" -->
Benchmark run 2025-01-20 14.56.28

| Method | WordCount | Mean | Error | StdDev | Median | Ratio | RatioSD | Allocated | Alloc Ratio |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| KTrie | 300 | 21.73 μs | 2.420 μs | 6.865 μs | 18.40 μs | 1.08 | 0.44 | 4.84 KB | 1.00 |
| Olve_List | 300 | 52.24 μs | 2.113 μs | 6.164 μs | 51.15 μs | 2.60 | 0.70 | 2.13 KB | 0.44 |
| Olve_Enumerate | 300 | 100.32 μs | 6.232 μs | 18.278 μs | 106.20 μs | 4.98 | 1.52 | 43.47 KB | 8.99 |
| KTrie | 10000 | 134.16 μs | 4.395 μs | 12.397 μs | 130.20 μs | 1.01 | 0.13 | 36.3 KB | 1.00 |
| Olve_List | 10000 | 491.58 μs | 22.514 μs | 66.029 μs | 495.90 μs | 3.69 | 0.59 | 40.36 KB | 1.11 |
| Olve_Enumerate | 10000 | 850.91 μs | 23.830 μs | 69.136 μs | 836.60 μs | 6.39 | 0.75 | 966.53 KB | 26.63 |
| KTrie | 300000 | 9,060.82 μs | 648.405 μs | 1,891.427 μs | 9,736.20 μs | 1.06 | 0.36 | 540.24 KB | 1.00 |
| Olve_List | 300000 | 12,922.32 μs | 255.049 μs | 570.455 μs | 12,962.65 μs | 1.51 | 0.40 | 1103.67 KB | 2.04 |
| Olve_Enumerate | 300000 | 21,377.13 μs | 426.857 μs | 1,022.722 μs | 21,600.20 μs | 2.49 | 0.67 | 15317.36 KB | 28.35 |


*[source](https://github.com/OliverVea/Olve.Trie/blob/638fe352a69452f957c0bc69c4807c7dc3c143ea/Olve.Trie.Benchmarks/Benchmarks/MatchBenchmark.cs)*
<!-- BENCHMARK_END -->
