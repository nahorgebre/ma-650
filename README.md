# Master Thesis

This repository contains the source for my Master Thesis "Is Science Effective at Creating Knowledge that Matters?".

## Repository Layout

`Thesis` contains the LaTeX code to produce the written Thesis. The document can be built using TeXnicCenter and MiKTeX.

`Code` contains the source code to reproduce the experiments in this Thesis.

## Requirements

- Python 3.x
- Maven 3.x
- Java 1.8 or later
- .NET Core 3.x

## Code Documentation

The layout of the  Code directory is as follows:
```
Code
├── Biomedical-Data-Integration
|   ├── DataTranslation
|   ├── IdentityResolution
|   └── DataFusion
└── Biomedical-Named-Entity-Recognition
    ├── ExtractPatentData
    └── DataPreparation
```

**Code/Biomedical-Data-Integration/DataTranslation**
`bash GetDatasets.sh` - Downloads input datasets from AWS S3.
`dotnet run` - Runs `DataTranslation` Code.

**Code/Biomedical-Data-Integration/IdentityResolution**

**Code/Biomedical-Data-Integration/DataFusion**

**Code/Biomedical-Named-Entity-Recognition/ExtractPatentData**
`bash GetDatasets.sh` - Downloads input datasets from AWS S3.
`dotnet run` - Runs `DataTranslation` Code.

**Code/Biomedical-Named-Entity-Recognition/DataPreparation**
