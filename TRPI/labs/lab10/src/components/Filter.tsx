import { FormControl, RadioGroup, FormControlLabel, Radio } from "@material-ui/core"
import {useState} from 'react';
import { useAppDispatch } from "../typedhook/hook";
import React from 'react';
import clsx from 'clsx';
import { makeStyles } from '@material-ui/core/styles';
import { RadioProps } from '@material-ui/core/Radio';
import '../styles/filters.css';
import { Box } from "@mui/material";
interface ICriteries{
    criteries:Array<string>,
    tittle:string,
    iconPath:string,
    action:Function,
}
const useStyles = makeStyles({
  root: {
    '&:hover': {
      backgroundColor: 'transparent',
    },
  },
  icon: {
    borderRadius: '50%',
    width: 16,
    height: 16,
    boxShadow: 'inset 0 0 0 1px rgba(16,22,26,.2), inset 0 -1px 0 rgba(16,22,26,.1)',
    backgroundColor: '#f5f8fa',
    backgroundImage: 'linear-gradient(180deg,hsla(0,0%,100%,.8),hsla(0,0%,100%,0))',
    '$root.Mui-focusVisible &': {
      outline: '2px auto rgba(19,124,189,.6)',
      outlineOffset: 2,
    },
    'input:hover ~ &': {
      backgroundColor: '#ebf1f5',
    },
    'input:disabled ~ &': {
      boxShadow: 'none',
      background: 'rgba(206,217,224,.5)',
    },
  },
  checkedIcon: {
    backgroundColor: '#0070FB',
    backgroundImage: 'linear-gradient(180deg,hsla(0,0%,100%,.1),hsla(0,0%,100%,0))',
    '&:before': {
      display: 'block',
      width: 16,
      height: 16,
      backgroundImage: 'radial-gradient(#fff,#fff 28%,transparent 32%)',
      content: '""',
    },
    'input:hover ~ &': {
      backgroundColor: '#0070FB',
    },
  },
});
function StyledRadio(props: RadioProps) {
  const classes = useStyles();

  return (
    <Radio
      className={classes.root}
      disableRipple
      color="default"
      checkedIcon={<span className={clsx(classes.icon, classes.checkedIcon)} />}
      icon={<span className={classes.icon} />}
      {...props}
    />
  );
}

const Filter:React.FC<ICriteries>=({criteries,tittle,iconPath,action})=>{
    const[visible,IsVisible]=useState(false);
    const dispatch = useAppDispatch();
    const handleMouseOver=()=>{
        IsVisible(true);
    }
    const handleMouseOut=()=>{
        IsVisible(false);
    }
    return(
        <div className="filterStyle">
            <FormControl component="fieldset">
            <div onMouseOver={handleMouseOver} onMouseOut={handleMouseOut}>
                <div className="headersSt">
                    <img className="imgSt" src={iconPath} alt="xer"></img>
                    <p className="titleStyle">{tittle}</p>
                </div>
                <RadioGroup className="OptionsStyle" name="gender1">
                    {visible && criteries.map((criteriy)=>(
                        <div className="qwe" onClick={()=>dispatch(action(criteriy))}>
                            <FormControlLabel key={criteriy.toString()} value={criteriy} control={<StyledRadio/>} label={ <Box component="div" fontSize={12}>
                            {criteriy} 
                            </Box>} />
                        </div>
                    ))}
                </RadioGroup>
            </div>
            </FormControl>
        </div>
    )
}

export default Filter;