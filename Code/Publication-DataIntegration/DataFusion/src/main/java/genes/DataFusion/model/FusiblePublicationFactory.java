package genes.DataFusion.model;

import java.util.Collections;
import java.util.LinkedList;
import java.util.List;

import org.apache.commons.lang3.StringUtils;

import de.uni_mannheim.informatik.dws.winter.model.FusibleFactory;
import de.uni_mannheim.informatik.dws.winter.model.RecordGroup;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;

import genes.DataFusion.model.Publication;

public class FusiblePublicationFactory implements FusibleFactory<Publication, Attribute>
{
    @Override
    public Publication createInstanceForFusion(RecordGroup<Publication, Attribute> cluster) 
    {
        List<String> ids = new LinkedList<>();

        for (Publication m : cluster.getRecords()) 
        {
            ids.add(m.getIdentifier());
        }

        Collections.sort(ids);

        String mergedId = StringUtils.join(ids, '+');

        return new Publication(mergedId, "fused");
    }
}