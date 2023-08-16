using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace TCB.Aplication.Domain;

public class ModelBase
{
    [Column("id")]
    public long Id { get; set; }
}