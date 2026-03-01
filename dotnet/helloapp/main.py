# # Check Python Version
# import sys
# print("Python version:", sys.version)
# # Import Required Libraries
# import numpy as np
# import pandas as pd
# import matplotlib.pyplot as plt

# from sklearn.model_selection import train_test_split
# from sklearn.preprocessing import StandardScaler
# from sklearn.pipeline import Pipeline
# from sklearn.linear_model import LogisticRegression
# from sklearn.metrics import accuracy_score, classification_report
# from sklearn.datasets import load_iris

# import random
# import os
# # Set Random Seeds (Reproducibility)
# SEED = 42

# np.random.seed(SEED)
# random.seed(SEED)
# os.environ["PYTHONHASHSEED"] = str(SEED)

# print("Random seed set to:", SEED)
# # Load Dataset
# iris = load_iris()

# X = iris.data
# y = iris.target

# print("Feature shape:", X.shape)
# print("Target shape:", y.shape)
# # Train / Test Split
# X_train, X_test, y_train, y_test = train_test_split(
#     X, y,
#     test_size=0.2,
#     random_state=SEED,
#     stratify=y
# )

# print("Train size:", X_train.shape[0])
# print("Test size:", X_test.shape[0])
# # Create ML Pipeline
# pipeline = Pipeline([
#     ("scaler", StandardScaler()),
#     ("model", LogisticRegression(random_state=SEED))
# ])

# pipeline
# # Train Model
# pipeline.fit(X_train, y_train)

# print("Model training completed.")
# # Evaluate Model
# y_pred = pipeline.predict(X_test)

# accuracy = accuracy_score(y_test, y_pred)

# print("Accuracy:", round(accuracy, 4))
# print("\nClassification Report:\n")
# print(classification_report(y_test, y_pred))
# # Basic Visualization
# plt.figure()
# plt.scatter(X[:, 0], X[:, 1], c=y)
# plt.xlabel("Feature 1")
# plt.ylabel("Feature 2")
# plt.title("Iris Dataset (First Two Features)")
# plt.show()
# # Simple Logging to Dictionary
# experiment_log = {
#     "model": "LogisticRegression",
#     "dataset": "Iris",
#     "seed": SEED,
#     "accuracy": accuracy
# }

# experiment_log
# # Save Log to CSV
# log_df = pd.DataFrame([experiment_log])
# log_df.to_csv("experiment_log.csv", index=False)

# print("Experiment log saved to experiment_log.csv")