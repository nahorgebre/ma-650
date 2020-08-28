import spacy
import scispacy

def getGeneNames(document):
    entityList = []
    nlp = spacy.load("en_ner_bionlp13cg_md")
    for ent in nlp(document).ents:
        if ent.label_=='GENE_OR_GENE_PRODUCT':
            entityList.append(ent.text)
    return '|'.join(entityList)