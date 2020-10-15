package genes.IdentityResolution.modelSAX;

import java.util.List;

import org.apache.logging.log4j.core.config.yaml.YamlConfiguration;

public class Gene {
    
    private int id;
    private String firstName;
    private String lastName;
    private int age;
    private String gender;
    private List<String> yvalueList;

    public int getId() {
        return id;
    }

    public void setId(int i) {
        this.id = i;
    }

    public String getFirstName() {
        return firstName;
    }

    public void setFirstName(String firstName) {
        this.firstName = firstName;
    }

    public String getLastName() {
        return lastName;
    }

    public void setLastName(String lastName) {
        this.lastName = lastName;
    }

    public int getAge() {
        return age;
    }

    public void setAge(int age) {
        this.age = age;
    }

    public String getGender() {
        return gender;
    }

    public void setGender(String gender) {
        this.gender = gender;
    }

    /*
    public String getYvalueList() {
        String x = "";
        for (String yvalue : this.yvalueList) {
            x = x + "," + yvalue;
        }
        return x;
    }
    */

    public String getYvalueList() {
        return convertListToString(yvalueList);
    }

    public void setYvalueList(String yvalue) {
        this.yvalueList.add(yvalue);
    }

    public String convertListToString(List<String> yvalueList) {
        StringBuilder text = new StringBuilder();
        for (String yvalue : yvalueList) {
            text.append(yvalue + ", ");
        }
        return text.toString();
    }

    @Override
    public String toString() {
        return "User [id=" + id + ", firstName=" + firstName + ", lastName=" + lastName + ", age=" + age + ", gender=" +
            gender + ", yvalues: " + getYvalueList() +" ]";
    }

}
