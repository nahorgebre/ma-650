from flair.data import Sentence
from flair.models import MultiTagger
from flair.tokenization import SciSpacyTokenizer

import sys
import csv

csv.field_size_limit(sys.maxsize)

tagger = MultiTagger.load("hunflair")

def getGeneNames(document):
    entityList = []
    sentence = Sentence(document, use_tokenizer=SciSpacyTokenizer())
    tagger.predict(sentence)
    for ent in sentence.get_spans():
        if 'Gene' in str(ent.labels):
            entityList.append(ent.text)
            print(ent.start_pos)
            print(ent.end_pos)
    return '|'.join(entityList)

def createTitleOutputFile(inputFileName, outputFileName):
    with open('data/output/' + outputFileName, 'w', newline='') as outputFile:
        writer = csv.writer(outputFile, delimiter='\t')
        writer.writerow(['patentNumber', 'patentDate', 'patentGeneNames'])
        with open('data/input/' + inputFileName) as inputFile:
            reader = csv.reader(inputFile, delimiter='\t')
            for row in reader:
                writer.writerow([row[0], row[1], getGeneNames(row[2])])

createTitleOutputFile('title.tsv', 'scispaCyTitleGene3.csv')