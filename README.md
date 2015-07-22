# SparseKNN

This contains, among file utils, three learning methods for sparse datasets : k-Nearest Neighbours, Nearest Centroids and a SGD for multiclass problems (with a high number of classes). They are designed to be able to work with very large dataset (millions of lines) without memory issues.

The Nearest Centroids follows a streaming calibration (everything is expanded accorded to the mapping, then added). 

The KNN implements an inverted index and the lookup has a parameter.

The SGD does not follow the exact implementation of a SGD and implements various regularizations.
