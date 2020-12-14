package genes.IdentityResolution.solutions;

// Java
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.nio.file.StandardCopyOption;

public class WinterLogFile {

    public static void deleteLog() throws Exception {

        Path source = Paths.get(System.getProperty("user.dir") + "/logs/winter.log");

        Files.delete(source);

    }

    public static void copyLogFile(String outputDirectory) throws IOException {

        Path source = Paths.get(System.getProperty("user.dir") + "/logs/winter.log");

        Path dest = Paths.get(System.getProperty("user.dir") + "/" + outputDirectory + "/winter.log");

        Files.copy(source, dest, StandardCopyOption.REPLACE_EXISTING);

        Files.delete(source);

    }
    
}