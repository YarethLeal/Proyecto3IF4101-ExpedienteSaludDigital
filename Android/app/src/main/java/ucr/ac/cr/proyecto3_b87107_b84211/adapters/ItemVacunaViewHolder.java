package ucr.ac.cr.proyecto3_b87107_b84211.adapters;

import android.view.View;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.constraintlayout.widget.ConstraintLayout;
import androidx.recyclerview.widget.RecyclerView;

import org.jetbrains.annotations.NotNull;

import ucr.ac.cr.proyecto3_b87107_b84211.R;

public class ItemVacunaViewHolder extends RecyclerView.ViewHolder{
    TextView vacuna;
    TextView fechaApli;
    ConstraintLayout layoutDetalles;
    TextView fechaProx;
    TextView descripcion;
    TextView verDetalles;

    public ItemVacunaViewHolder(@NonNull @NotNull View itemView) {
        super(itemView);
        vacuna= itemView.findViewById(R.id.txtVacuna);
        fechaApli= itemView.findViewById(R.id.txtFechaA);
        layoutDetalles=itemView.findViewById(R.id.itemMasDetallesV);
        fechaProx=itemView.findViewById(R.id.txtProxAVacunaValor);
        descripcion=itemView.findViewById(R.id.txtDescripcionVValor);
        verDetalles=itemView.findViewById(R.id.txtDetallesV);

    }
}
