# Master Thesis

This repository contains the source for my Master Thesis "Is Science Effective at Creating Knowledge that Matters?".

## Repository Layout

`Thesis` contains the LaTeX code to produce the written Thesis. The document can be built using the `build.sh` script to compile the Thesis and output `thesis.pdf`.

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

`dotnet run` - Runs `DataTranslation` code and upload results to AWS S3.

**Code/Biomedical-Data-Integration/IdentityResolution**

`bash GetDatasets.sh` - Downloads input datasets from AWS S3.

`bash RunIdentityResolution.sh` - Runs `IdentityResolution` code and upload results to AWS S3.

**Code/Biomedical-Data-Integration/DataFusion**

`bash GetDatasets.sh` - Downloads input datasets from AWS S3.

`bash RunDataFusion.sh` - Runs `DataFusion` code and upload results to AWS S3.

**Code/Biomedical-Named-Entity-Recognition/ExtractPatentData**

`bash GetDatasets.sh` - Downloads input datasets from AWS S3.

`dotnet run` - Runs `ExtractPatentData` code and uploads results to AWS S3.
<br/>

**Code/Biomedical-Named-Entity-Recognition/DataPreparation**
<br/>
