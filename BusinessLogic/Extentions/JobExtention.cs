namespace ISRDataAccess.Extentions;
using BusinessLogic;
using Models;

public static class JobExtention
{
    public static JobModel ToJobModel(this Job job)
    {
       
        var dst = new JobModel
        { 
           

        };

        return dst;
    }

    public static Job ToJob(this JobModel job)
    {
        var dst = new Job
        {
           
        };

        return dst;
    }

}

