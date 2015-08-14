# CDiscout-Classification

This code contains, among file utils, various learning methods designed for sparse datasets, where keys are represented by strings. This allows to keep track of "what is going on" in every algorithm (what do the centroids look like ? what do the decision trees look like ?...).

- k-Nearest Neighbours (based on a TF-IDF representation of the documents)
- Nearest Centroids (based on a TF-IDF representation of the documents)
- Decision tree (proposing formulas such as if(not word1 in doc and word2 in doc and word3 in doc) then Cat k )
- Bag of Words
- SGD for multiclass problems (with a high number of classes)

Optimizations include :
- Inversion of indexes
- Pre-allocation of memory
- Unsafe code
 
Part of the code come from other sources :
- Stemming is a C# port of Snowball
- Text to TFIDF utils 
