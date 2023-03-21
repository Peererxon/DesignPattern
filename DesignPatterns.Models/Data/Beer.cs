using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesignPatterns.Models.Data;

public partial class Beer
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int BeerId { get; set; }

    public string Name { get; set; }

    public string Style { get; set; }

    public Guid? Bid { get; set; }

    public virtual Brand BidNavigation { get; set; }
}
