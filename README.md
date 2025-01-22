# Olve.Trie

## Overview


## Introduction


## Benchmarks

Benchmarks are a comparison between:

- `Olve` - This library
- `KTrie` - [kpol/trie](https://github.com/kpol/trie)

### Initialization
<!-- BENCHMARK_ID: "construct-trie" -->

Benchmark run 2025-01-22 15.36.35

| Method | WordCount | Mean | Error | StdDev | Median | Ratio | RatioSD | Gen0 | Gen1 | Gen2 | Allocated | Alloc Ratio |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| KTrie | 300 | 71.01 μs | 1.078 μs | 1.972 μs | 70.78 μs | 1.00 | 0.04 | - | - | - | 150.01 KB | 1.00 |
| Olve_NaiveArrayTrie | 300 | 74.10 μs | 1.466 μs | 3.965 μs | 72.62 μs | 1.04 | 0.06 | - | - | - | 165.17 KB | 1.10 |
| KTrie | 10000 | 1,755.26 μs | 33.531 μs | 37.270 μs | 1,748.21 μs | 1.00 | 0.03 | 187.5000 | 125.0000 | - | 3869.22 KB | 1.00 |
| Olve_NaiveArrayTrie | 10000 | 1,638.77 μs | 32.294 μs | 40.842 μs | 1,637.38 μs | 0.93 | 0.03 | 187.5000 | 125.0000 | - | 4211.36 KB | 1.09 |
| KTrie | 300000 | 289,338.33 μs | 5,711.963 μs | 7,818.600 μs | 289,601.88 μs | 1.00 | 0.04 | 5062.5000 | 5000.0000 | 1312.5000 | 69322.64 KB | 1.00 |
| Olve_NaiveArrayTrie | 300000 | 244,087.10 μs | 4,858.811 μs | 5,967.057 μs | 242,587.83 μs | 0.84 | 0.03 | 4937.5000 | 4875.0000 | 1312.5000 | 67239.13 KB | 0.97 |


*[source](https://github.com/OliverVea/Olve.Trie/blob/06805afb25bca137b5342c6f12e1a92404cb117e/Olve.Trie.Benchmarks/Benchmarks/ConstructTrieBenchmark.cs)*
<!-- BENCHMARK_END -->

### Prefix Match
<!-- BENCHMARK_ID: "list-with-prefix" -->

Benchmark run 2025-01-22 15.39.22

| Method | WordCount | Mean | Error | StdDev | Median | Ratio | RatioSD | Gen0 | Gen1 | Allocated | Alloc Ratio |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| KTrie_StartsWith | 300 | 15.61 μs | 2.808 μs | 8.278 μs | 9.584 μs | 1.28 | 0.91 | - | - | 6.79 KB | 1.00 |
| Olve_NaiveArrayTrie_ListWithPrefix | 300 | 40.61 μs | 0.802 μs | 1.968 μs | 40.306 μs | 3.32 | 1.40 | - | - | 14.83 KB | 2.19 |
| Olve_NaiveArrayTrie_EnumerateWithPrefix | 300 | 37.18 μs | 5.969 μs | 17.600 μs | 47.944 μs | 3.04 | 2.01 | - | - | 17.22 KB | 2.54 |
| KTrie_StartsWith | 10000 | 119.82 μs | 2.363 μs | 3.608 μs | 119.159 μs | 1.00 | 0.04 | - | - | 52.57 KB | 1.00 |
| Olve_NaiveArrayTrie_ListWithPrefix | 10000 | 128.70 μs | 2.545 μs | 6.147 μs | 129.581 μs | 1.08 | 0.06 | - | - | 305.74 KB | 5.82 |
| Olve_NaiveArrayTrie_EnumerateWithPrefix | 10000 | 174.82 μs | 7.814 μs | 23.040 μs | 161.387 μs | 1.46 | 0.20 | - | - | 313.54 KB | 5.96 |
| KTrie_StartsWith | 300000 | 4,246.22 μs | 85.696 μs | 218.123 μs | 4,196.991 μs | 1.00 | 0.07 | - | - | 982.99 KB | 1.00 |
| Olve_NaiveArrayTrie_ListWithPrefix | 300000 | 5,290.56 μs | 56.416 μs | 52.772 μs | 5,277.156 μs | 1.25 | 0.05 | 187.5000 | 62.5000 | 4826.76 KB | 4.91 |
| Olve_NaiveArrayTrie_EnumerateWithPrefix | 300000 | 5,698.99 μs | 113.924 μs | 202.500 μs | 5,763.453 μs | 1.34 | 0.07 | 187.5000 | 62.5000 | 4840.67 KB | 4.92 |


*[source](https://github.com/OliverVea/Olve.Trie/blob/06805afb25bca137b5342c6f12e1a92404cb117e/Olve.Trie.Benchmarks/Benchmarks/ListWithPrefixBenchmark.cs)*
<!-- BENCHMARK_END -->

<!-- BENCHMARK_ID: "enumerate-k-prefix" -->

Benchmark run 2025-01-22 15.42.29

| Method | WordCount | K | Mean | Error | StdDev | Median | Ratio | RatioSD | Gen0 | Gen1 | Allocated | Alloc Ratio |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| KTrie_StartsWith | 300 | 5 | 13.29 μs | 2.050 μs | 5.949 μs | 10.35 μs | 1.16 | 0.66 | - | - | 7.62 KB | 1.00 |
| Olve_NaiveArrayTrie_EnumerateWithPrefix | 300 | 5 | 30.41 μs | 2.494 μs | 7.236 μs | 32.58 μs | 2.65 | 1.07 | - | - | 11.55 KB | 1.52 |
| KTrie_StartsWith | 300 | 500 | 29.91 μs | 2.190 μs | 6.457 μs | 29.45 μs | 1.07 | 0.42 | - | - | 7.88 KB | 1.00 |
| Olve_NaiveArrayTrie_EnumerateWithPrefix | 300 | 500 | 49.09 μs | 4.620 μs | 13.550 μs | 53.19 μs | 1.76 | 0.75 | - | - | 17.37 KB | 2.20 |
| KTrie_StartsWith | 300 | 50000 | 18.86 μs | 3.010 μs | 8.875 μs | 12.89 μs | 1.21 | 0.76 | - | - | 7.88 KB | 1.00 |
| Olve_NaiveArrayTrie_EnumerateWithPrefix | 300 | 50000 | 29.18 μs | 5.885 μs | 17.351 μs | 17.55 μs | 1.87 | 1.39 | - | - | 17.37 KB | 2.20 |
| KTrie_StartsWith | 10000 | 5 | 25.43 μs | 0.501 μs | 1.034 μs | 25.24 μs | 1.00 | 0.06 | - | - | 33.09 KB | 1.00 |
| Olve_NaiveArrayTrie_EnumerateWithPrefix | 10000 | 5 | 14.04 μs | 0.276 μs | 0.329 μs | 14.16 μs | 0.55 | 0.02 | - | - | 23.01 KB | 0.70 |
| KTrie_StartsWith | 10000 | 500 | 105.63 μs | 2.109 μs | 4.063 μs | 104.53 μs | 1.00 | 0.05 | - | - | 50.85 KB | 1.00 |
| Olve_NaiveArrayTrie_EnumerateWithPrefix | 10000 | 500 | 131.44 μs | 2.563 μs | 4.211 μs | 130.43 μs | 1.25 | 0.06 | - | - | 238.97 KB | 4.70 |
| KTrie_StartsWith | 10000 | 50000 | 123.13 μs | 2.410 μs | 5.239 μs | 122.22 μs | 1.00 | 0.06 | - | - | 53.66 KB | 1.00 |
| Olve_NaiveArrayTrie_EnumerateWithPrefix | 10000 | 50000 | 167.58 μs | 3.295 μs | 8.446 μs | 168.17 μs | 1.36 | 0.09 | - | - | 289.94 KB | 5.40 |
| KTrie_StartsWith | 300000 | 5 | 30.14 μs | 0.598 μs | 0.665 μs | 30.04 μs | 1.00 | 0.03 | - | - | 38.52 KB | 1.00 |
| Olve_NaiveArrayTrie_EnumerateWithPrefix | 300000 | 5 | 16.35 μs | 0.326 μs | 0.456 μs | 16.33 μs | 0.54 | 0.02 | - | - | 19.16 KB | 0.50 |
| KTrie_StartsWith | 300000 | 500 | 942.26 μs | 18.652 μs | 32.174 μs | 937.10 μs | 1.00 | 0.05 | - | - | 478.68 KB | 1.00 |
| Olve_NaiveArrayTrie_EnumerateWithPrefix | 300000 | 500 | 598.01 μs | 10.937 μs | 18.273 μs | 597.00 μs | 0.64 | 0.03 | - | - | 525.04 KB | 1.10 |
| KTrie_StartsWith | 300000 | 50000 | 4,292.94 μs | 82.234 μs | 72.898 μs | 4,261.97 μs | 1.00 | 0.02 | - | - | 984.08 KB | 1.00 |
| Olve_NaiveArrayTrie_EnumerateWithPrefix | 300000 | 50000 | 5,376.62 μs | 51.268 μs | 45.448 μs | 5,363.72 μs | 1.25 | 0.02 | 187.5000 | 62.5000 | 4180.67 KB | 4.25 |


*[source](https://github.com/OliverVea/Olve.Trie/blob/06805afb25bca137b5342c6f12e1a92404cb117e/Olve.Trie.Benchmarks/Benchmarks/EnumerateTopKWithPrefixBenchmark.cs)*
<!-- BENCHMARK_END -->

<!-- BENCHMARK_ID: "contains" -->

Benchmark run 2025-01-22 15.52.22

| Method | TrieSize | Words | MissRate | Mean | Error | StdDev | Median | Ratio | RatioSD |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| KTrie | 100 | 5 | 0 | 570.08 ns | 210.944 ns | 618.66 ns | 156.25 ns | 2.88 | 4.23 |
| Olve_NaiveArrayTrie | 100 | 5 | 0 | 1,084.61 ns | 51.030 ns | 146.41 ns | 1,037.50 ns | 5.48 | 3.81 |
| HashSet | 100 | 5 | 0 | 144.96 ns | 12.366 ns | 34.06 ns | 140.62 ns | 0.73 | 0.54 |
| KTrie | 100 | 5 | 0.5 | 153.08 ns | 17.713 ns | 45.41 ns | 150.00 ns | 1.07 | 0.41 |
| Olve_NaiveArrayTrie | 100 | 5 | 0.5 | 568.94 ns | 169.982 ns | 501.20 ns | 156.25 ns | 3.96 | 3.70 |
| HashSet | 100 | 5 | 0.5 | 138.90 ns | 22.215 ns | 63.38 ns | 115.62 ns | 0.97 | 0.51 |
| KTrie | 100 | 5 | 1 | 1,138.14 ns | 39.290 ns | 114.61 ns | 1,100.00 ns | 1.01 | 0.14 |
| Olve_NaiveArrayTrie | 100 | 5 | 1 | 657.55 ns | 25.471 ns | 71.42 ns | 637.50 ns | 0.58 | 0.08 |
| HashSet | 100 | 5 | 1 | 90.44 ns | 11.568 ns | 31.27 ns | 87.50 ns | 0.08 | 0.03 |
| KTrie | 100 | 500 | 0 | 61,672.12 ns | 15,157.470 ns | 44,692.15 ns | 95,596.88 ns | 2.59 | 3.64 |
| Olve_NaiveArrayTrie | 100 | 500 | 0 | 52,390.62 ns | 1,005.858 ns | 891.67 ns | 52,346.88 ns | 2.20 | 2.15 |
| HashSet | 100 | 500 | 0 | 11,592.41 ns | 840.076 ns | 2,383.15 ns | 11,500.00 ns | 0.49 | 0.50 |
| KTrie | 100 | 500 | 0.5 | 111,435.42 ns | 1,936.361 ns | 1,811.27 ns | 110,937.50 ns | 1.00 | 0.02 |
| Olve_NaiveArrayTrie | 100 | 500 | 0.5 | 40,123.00 ns | 7,458.730 ns | 21,992.24 ns | 52,337.50 ns | 0.36 | 0.20 |
| HashSet | 100 | 500 | 0.5 | 10,550.14 ns | 763.526 ns | 2,141.01 ns | 10,487.50 ns | 0.09 | 0.02 |
| KTrie | 100 | 500 | 1 | 54,578.31 ns | 13,613.403 ns | 40,139.43 ns | 86,228.12 ns | 2.84 | 4.13 |
| Olve_NaiveArrayTrie | 100 | 500 | 1 | 42,631.85 ns | 852.703 ns | 1,760.98 ns | 42,343.75 ns | 2.22 | 2.25 |
| HashSet | 100 | 500 | 1 | 11,069.36 ns | 899.022 ns | 2,535.71 ns | 11,206.25 ns | 0.58 | 0.61 |
| KTrie | 100 | 50000 | 0 | 1,311,356.93 ns | 26,057.596 ns | 64,892.46 ns | 1,278,850.00 ns | 1.00 | 0.07 |
| Olve_NaiveArrayTrie | 100 | 50000 | 0 | 1,199,284.38 ns | 24,858.464 ns | 73,295.75 ns | 1,170,306.25 ns | 0.92 | 0.07 |
| HashSet | 100 | 50000 | 0 | 862,692.92 ns | 14,965.481 ns | 28,473.38 ns | 856,168.75 ns | 0.66 | 0.04 |
| KTrie | 100 | 50000 | 0.5 | 1,319,829.45 ns | 26,317.304 ns | 75,084.75 ns | 1,289,912.50 ns | 1.00 | 0.08 |
| Olve_NaiveArrayTrie | 100 | 50000 | 0.5 | 1,170,896.31 ns | 25,454.356 ns | 75,052.75 ns | 1,155,237.50 ns | 0.89 | 0.07 |
| HashSet | 100 | 50000 | 0.5 | 873,483.50 ns | 12,753.046 ns | 17,024.95 ns | 880,718.75 ns | 0.66 | 0.04 |
| KTrie | 100 | 50000 | 1 | 1,374,909.88 ns | 28,511.574 ns | 84,067.03 ns | 1,393,812.50 ns | 1.00 | 0.09 |
| Olve_NaiveArrayTrie | 100 | 50000 | 1 | 1,125,989.42 ns | 21,222.274 ns | 17,721.56 ns | 1,126,662.50 ns | 0.82 | 0.05 |
| HashSet | 100 | 50000 | 1 | 888,026.27 ns | 17,319.196 ns | 29,409.31 ns | 885,721.88 ns | 0.65 | 0.05 |
| KTrie | 10000 | 5 | 0 | 138.25 ns | 6.576 ns | 17.55 ns | 137.50 ns | 1.01 | 0.17 |
| Olve_NaiveArrayTrie | 10000 | 5 | 0 | 114.58 ns | 7.073 ns | 19.36 ns | 112.50 ns | 0.84 | 0.17 |
| HashSet | 10000 | 5 | 0 | 122.81 ns | 7.661 ns | 21.86 ns | 125.00 ns | 0.90 | 0.19 |
| KTrie | 10000 | 5 | 0.5 | 187.50 ns | 8.166 ns | 23.56 ns | 187.50 ns | 1.02 | 0.18 |
| Olve_NaiveArrayTrie | 10000 | 5 | 0.5 | 169.18 ns | 6.848 ns | 18.74 ns | 168.75 ns | 0.92 | 0.15 |
| HashSet | 10000 | 5 | 0.5 | 124.80 ns | 7.051 ns | 20.12 ns | 121.88 ns | 0.68 | 0.14 |
| KTrie | 10000 | 5 | 1 | 198.96 ns | 9.753 ns | 26.20 ns | 203.12 ns | 1.02 | 0.19 |
| Olve_NaiveArrayTrie | 10000 | 5 | 1 | 199.85 ns | 9.449 ns | 25.71 ns | 193.75 ns | 1.02 | 0.19 |
| HashSet | 10000 | 5 | 1 | 109.54 ns | 11.577 ns | 33.59 ns | 112.50 ns | 0.56 | 0.19 |
| KTrie | 10000 | 500 | 0 | 22,612.17 ns | 444.883 ns | 967.14 ns | 22,650.00 ns | 1.00 | 0.06 |
| Olve_NaiveArrayTrie | 10000 | 500 | 0 | 17,945.29 ns | 355.104 ns | 884.33 ns | 17,862.50 ns | 0.80 | 0.05 |
| HashSet | 10000 | 500 | 0 | 5,320.44 ns | 136.539 ns | 369.14 ns | 5,250.00 ns | 0.24 | 0.02 |
| KTrie | 10000 | 500 | 0.5 | 24,309.32 ns | 485.514 ns | 1,095.89 ns | 24,375.00 ns | 1.00 | 0.06 |
| Olve_NaiveArrayTrie | 10000 | 500 | 0.5 | 23,106.34 ns | 461.270 ns | 1,131.50 ns | 23,131.25 ns | 0.95 | 0.06 |
| HashSet | 10000 | 500 | 0.5 | 4,896.52 ns | 109.306 ns | 301.06 ns | 4,862.50 ns | 0.20 | 0.02 |
| KTrie | 10000 | 500 | 1 | 26,062.50 ns | 520.410 ns | 778.92 ns | 26,115.62 ns | 1.00 | 0.04 |
| Olve_NaiveArrayTrie | 10000 | 500 | 1 | 26,492.67 ns | 682.252 ns | 1,990.16 ns | 25,918.75 ns | 1.02 | 0.08 |
| HashSet | 10000 | 500 | 1 | 4,134.80 ns | 96.180 ns | 264.91 ns | 4,106.25 ns | 0.16 | 0.01 |
| KTrie | 10000 | 50000 | 0 | 4,123,998.05 ns | 74,818.355 ns | 73,481.63 ns | 4,105,946.88 ns | 1.00 | 0.02 |
| Olve_NaiveArrayTrie | 10000 | 50000 | 0 | 3,920,975.00 ns | 74,364.037 ns | 76,366.39 ns | 3,913,768.75 ns | 0.95 | 0.02 |
| HashSet | 10000 | 50000 | 0 | 979,046.32 ns | 18,005.860 ns | 29,076.11 ns | 981,578.12 ns | 0.24 | 0.01 |
| KTrie | 10000 | 50000 | 0.5 | 4,129,988.33 ns | 81,441.462 ns | 76,180.39 ns | 4,111,281.25 ns | 1.00 | 0.03 |
| Olve_NaiveArrayTrie | 10000 | 50000 | 0.5 | 3,934,449.67 ns | 76,911.883 ns | 85,487.35 ns | 3,889,725.00 ns | 0.95 | 0.03 |
| HashSet | 10000 | 50000 | 0.5 | 975,418.53 ns | 19,140.628 ns | 28,056.09 ns | 982,075.00 ns | 0.24 | 0.01 |
| KTrie | 10000 | 50000 | 1 | 4,220,904.43 ns | 84,209.018 ns | 109,495.52 ns | 4,270,200.00 ns | 1.00 | 0.04 |
| Olve_NaiveArrayTrie | 10000 | 50000 | 1 | 3,851,445.42 ns | 59,789.535 ns | 55,927.17 ns | 3,837,062.50 ns | 0.91 | 0.03 |
| HashSet | 10000 | 50000 | 1 | 955,532.14 ns | 18,952.734 ns | 16,801.11 ns | 953,909.38 ns | 0.23 | 0.01 |
| KTrie | 100000 | 5 | 0 | 320.45 ns | 8.190 ns | 24.02 ns | 318.75 ns | 1.01 | 0.11 |
| Olve_NaiveArrayTrie | 100000 | 5 | 0 | 204.90 ns | 9.199 ns | 26.69 ns | 200.00 ns | 0.64 | 0.10 |
| HashSet | 100000 | 5 | 0 | 174.16 ns | 6.293 ns | 18.26 ns | 175.00 ns | 0.55 | 0.07 |
| KTrie | 100000 | 5 | 0.5 | 411.76 ns | 8.849 ns | 23.77 ns | 406.25 ns | 1.00 | 0.08 |
| Olve_NaiveArrayTrie | 100000 | 5 | 0.5 | 301.66 ns | 12.548 ns | 36.60 ns | 296.88 ns | 0.74 | 0.10 |
| HashSet | 100000 | 5 | 0.5 | 184.21 ns | 6.258 ns | 18.16 ns | 181.25 ns | 0.45 | 0.05 |
| KTrie | 100000 | 5 | 1 | 395.25 ns | 8.966 ns | 25.87 ns | 393.75 ns | 1.00 | 0.09 |
| Olve_NaiveArrayTrie | 100000 | 5 | 1 | 377.06 ns | 12.649 ns | 36.70 ns | 368.75 ns | 0.96 | 0.11 |
| HashSet | 100000 | 5 | 1 | 141.14 ns | 4.941 ns | 14.41 ns | 143.75 ns | 0.36 | 0.04 |
| KTrie | 100000 | 500 | 0 | 38,960.42 ns | 766.444 ns | 1,074.45 ns | 38,662.50 ns | 1.00 | 0.04 |
| Olve_NaiveArrayTrie | 100000 | 500 | 0 | 24,333.75 ns | 464.984 ns | 434.95 ns | 24,425.00 ns | 0.63 | 0.02 |
| HashSet | 100000 | 500 | 0 | 6,323.51 ns | 126.951 ns | 244.59 ns | 6,321.88 ns | 0.16 | 0.01 |
| KTrie | 100000 | 500 | 0.5 | 51,394.20 ns | 902.815 ns | 800.32 ns | 51,515.62 ns | 1.00 | 0.02 |
| Olve_NaiveArrayTrie | 100000 | 500 | 0.5 | 41,182.03 ns | 737.533 ns | 1,148.25 ns | 41,062.50 ns | 0.80 | 0.03 |
| HashSet | 100000 | 500 | 0.5 | 5,875.00 ns | 117.807 ns | 251.06 ns | 5,906.25 ns | 0.11 | 0.01 |
| KTrie | 100000 | 500 | 1 | 67,358.19 ns | 1,341.817 ns | 3,291.50 ns | 66,525.00 ns | 1.00 | 0.07 |
| Olve_NaiveArrayTrie | 100000 | 500 | 1 | 61,961.12 ns | 1,236.029 ns | 3,362.71 ns | 61,709.38 ns | 0.92 | 0.07 |
| HashSet | 100000 | 500 | 1 | 4,828.70 ns | 95.998 ns | 134.58 ns | 4,850.00 ns | 0.07 | 0.00 |
| KTrie | 100000 | 50000 | 0 | 9,745,249.35 ns | 188,168.051 ns | 275,814.31 ns | 9,792,025.00 ns | 1.00 | 0.04 |
| Olve_NaiveArrayTrie | 100000 | 50000 | 0 | 7,905,597.50 ns | 136,812.826 ns | 127,974.80 ns | 7,876,731.25 ns | 0.81 | 0.03 |
| HashSet | 100000 | 50000 | 0 | 1,259,653.78 ns | 25,073.114 ns | 68,213.26 ns | 1,242,359.38 ns | 0.13 | 0.01 |
| KTrie | 100000 | 50000 | 0.5 | 9,244,281.73 ns | 94,802.435 ns | 79,164.33 ns | 9,247,962.50 ns | 1.00 | 0.01 |
| Olve_NaiveArrayTrie | 100000 | 50000 | 0.5 | 7,905,573.90 ns | 137,544.121 ns | 141,247.69 ns | 7,914,793.75 ns | 0.86 | 0.02 |
| HashSet | 100000 | 50000 | 0.5 | 1,270,177.70 ns | 25,333.172 ns | 63,555.98 ns | 1,258,206.25 ns | 0.14 | 0.01 |
| KTrie | 100000 | 50000 | 1 | 9,539,024.58 ns | 161,969.787 ns | 151,506.64 ns | 9,499,875.00 ns | 1.00 | 0.02 |
| Olve_NaiveArrayTrie | 100000 | 50000 | 1 | 8,923,495.31 ns | 169,876.680 ns | 132,628.54 ns | 8,918,381.25 ns | 0.94 | 0.02 |
| HashSet | 100000 | 50000 | 1 | 1,112,666.07 ns | 7,127.159 ns | 6,318.04 ns | 1,110,812.50 ns | 0.12 | 0.00 |


*[source](https://github.com/OliverVea/Olve.Trie/blob/06805afb25bca137b5342c6f12e1a92404cb117e/Olve.Trie.Benchmarks/Benchmarks/ContainsBenchmark.cs)*
<!-- BENCHMARK_END -->
