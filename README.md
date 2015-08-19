# CDiscout-Classification

This code contains, among file utils, various learning methods designed for sparse datasets, where keys are represented by strings. This allows to keep track of "what is going on" in every algorithm : what do the centroids look like ? what do the decision trees look like ?

- k-Nearest Neighbours (based on a TF-IDF representation of the documents)
- Nearest Centroids (based on a TF-IDF representation of the documents)
- "Logic" Decision tree, proposing formulas such as if(not word1 in doc and word2 in doc and word3 in doc) then Cat k
- SGD for multiclass problems (with a high number of classes)
- Bag of Words (not used in the final solution)
 
Optimizations include :
- Inversion of indexes
- Parallelization
- Pre-allocation of memory
- Unsafe code
 
Some parts of the code come from other sources :
- Stemming is a C# port of Snowball
- Text to TFIDF utils 
 


The final solution has been generated following these steps :
- Shuffle the training file according to 7 seeds : 0,1...,6
- Down-sample each file so that there a no more than 1000 elements per class
- On each file train : a 3-NN model (lookup parameter 0.25, no stemming), a Nearest Centroid model (using PureInteractions mapping, stemmed), A hierarchical SGD model, a SGD model and a logic decision tree (max depth 4500, min elements per leaf = 8, no stemming)

They correspond to the default models in the main window.
